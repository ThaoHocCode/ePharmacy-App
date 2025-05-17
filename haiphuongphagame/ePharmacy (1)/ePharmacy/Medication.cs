using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy
{
    class Medication
    {
        private readonly Database db;

        public Medication()
        {
            db = new Database();
        }

        public DataTable GetAllMedications()
        {
            string query = "SELECT * FROM SanPham";
            return db.Execute(query);
        }

        public DataTable GetDistinctTypes()
        {
            string query = "SELECT DISTINCT Type FROM SanPham WHERE Type IS NOT NULL";
            return db.Execute(query);
        }

        public DataTable GetDistinctGroups()
        {
            string query = "SELECT DISTINCT [Group] FROM SanPham WHERE [Group] IS NOT NULL";
            return db.Execute(query);
        }

        public DataTable PersonalData()
        {
            string query = "SELECT * FROM [User]";
            return db.Execute(query);
        }

        public DataTable FilterMedications(string typeFilter, string groupFilter)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM SanPham");
            List<SqlParameter> parameters = new List<SqlParameter>();

            bool hasWhereClause = false;

            if (!string.IsNullOrEmpty(groupFilter) && groupFilter != "Không lọc")
            {
                queryBuilder.Append(" WHERE [Group] = @Group");
                parameters.Add(new SqlParameter("@Group", groupFilter));
                hasWhereClause = true;
            }

            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Không lọc")
            {
                if (hasWhereClause)
                {
                    queryBuilder.Append(" AND Type = @Type");
                }
                else
                {
                    queryBuilder.Append(" WHERE Type = @Type");
                }
                parameters.Add(new SqlParameter("@Type", typeFilter));
            }

            return db.ExecuteWithParameters(queryBuilder.ToString(), parameters.ToArray());
        }

        public int AddMedication(string type, string group, string goodsCode, string name,
                                string activeElement, string manufacturer, string packaging,
                                string cost, string inventory, string expiryDate)
        {
            string query = @"INSERT INTO SanPham (ID, Type, [Group], GoodsCode, CommodityName, ActiveElement, 
                            Manufacturer, Packaging, Cost, Iventory, ExpiryDate)
                            VALUES (@ID, @Type, @Group, @GoodsCode, @CommodityName, @ActiveElement, 
                            @Manufacturer, @Packaging, @Cost, @Iventory, @ExpiryDate)";

            // Tạo ID mới (Guid)
            Guid newId = Guid.NewGuid();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ID", newId),
                new SqlParameter("@Type", string.IsNullOrEmpty(type) ? DBNull.Value : (object)type),
                new SqlParameter("@Group", string.IsNullOrEmpty(group) ? DBNull.Value : (object)group),
                new SqlParameter("@GoodsCode", goodsCode),
                new SqlParameter("@CommodityName", name),
                new SqlParameter("@ActiveElement", string.IsNullOrEmpty(activeElement) ? DBNull.Value : (object)activeElement),
                new SqlParameter("@Manufacturer", string.IsNullOrEmpty(manufacturer) ? DBNull.Value : (object)manufacturer),
                new SqlParameter("@Packaging", string.IsNullOrEmpty(packaging) ? DBNull.Value : (object)packaging)
            };

            // Xử lý giá nhập
            if (string.IsNullOrWhiteSpace(cost))
            {
                parameters.Add(new SqlParameter("@Cost", DBNull.Value));
            }
            else
            {
                string costText = cost.Replace(',', '.');
                if (double.TryParse(costText, NumberStyles.Any, CultureInfo.InvariantCulture, out double costValue))
                {
                    parameters.Add(new SqlParameter("@Cost", costValue));
                }
                else
                {
                    throw new FormatException("Giá trị 'Giá nhập' không hợp lệ.");
                }
            }

            // Xử lý tồn kho
            if (string.IsNullOrWhiteSpace(inventory))
            {
                parameters.Add(new SqlParameter("@Iventory", DBNull.Value));
            }
            else
            {
                string inventoryText = inventory.Replace(',', '.');
                if (double.TryParse(inventoryText, NumberStyles.Any, CultureInfo.InvariantCulture, out double inventoryValue))
                {
                    parameters.Add(new SqlParameter("@Iventory", inventoryValue));
                }
                else
                {
                    throw new FormatException("Giá trị 'Tồn kho' không hợp lệ.");
                }
            }

            // Xử lý ngày hết hạn
            if (string.IsNullOrWhiteSpace(expiryDate))
            {
                parameters.Add(new SqlParameter("@ExpiryDate", DBNull.Value));
            }
            else
            {
                if (DateTime.TryParse(expiryDate, out DateTime expiryDateValue))
                {
                    parameters.Add(new SqlParameter("@ExpiryDate", expiryDateValue));
                }
                else
                {
                    throw new FormatException("Định dạng 'Ngày hết hạn' không hợp lệ.");
                }
            }

            return db.ExecuteNonQuery(query, parameters.ToArray());
        }

        public int UpdateMedication(string id, string type, string group, string goodsCode, string name,
                                  string activeElement, string manufacturer, string packaging,
                                  string cost, string inventory, string expiryDate)
        {
            // Kiểm tra và chuyển đổi ID
            if (!Guid.TryParse(id, out Guid medicationId))
            {
                throw new FormatException("ID không hợp lệ. ID phải là một GUID hợp lệ.");
            }

            string query = @"UPDATE SanPham SET 
                            Type = @Type, 
                            [Group] = @Group, 
                            GoodsCode = @GoodsCode, 
                            CommodityName = @CommodityName, 
                            ActiveElement = @ActiveElement, 
                            Manufacturer = @Manufacturer, 
                            Packaging = @Packaging, 
                            Cost = @Cost, 
                            Iventory = @Iventory, 
                            ExpiryDate = @ExpiryDate
                            WHERE ID = @ID";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ID", medicationId),
                new SqlParameter("@Type", string.IsNullOrEmpty(type) ? DBNull.Value : (object)type),
                new SqlParameter("@Group", string.IsNullOrEmpty(group) ? DBNull.Value : (object)group),
                new SqlParameter("@GoodsCode", goodsCode),
                new SqlParameter("@CommodityName", name),
                new SqlParameter("@ActiveElement", string.IsNullOrEmpty(activeElement) ? DBNull.Value : (object)activeElement),
                new SqlParameter("@Manufacturer", string.IsNullOrEmpty(manufacturer) ? DBNull.Value : (object)manufacturer),
                new SqlParameter("@Packaging", string.IsNullOrEmpty(packaging) ? DBNull.Value : (object)packaging)
            };

            // Xử lý giá nhập
            if (string.IsNullOrWhiteSpace(cost))
            {
                parameters.Add(new SqlParameter("@Cost", DBNull.Value));
            }
            else
            {
                string costText = cost.Replace(',', '.');
                if (double.TryParse(costText, NumberStyles.Any, CultureInfo.InvariantCulture, out double costValue))
                {
                    parameters.Add(new SqlParameter("@Cost", costValue));
                }
                else
                {
                    throw new FormatException("Giá trị 'Giá nhập' không hợp lệ.");
                }
            }

            // Xử lý tồn kho
            if (string.IsNullOrWhiteSpace(inventory))
            {
                parameters.Add(new SqlParameter("@Iventory", DBNull.Value));
            }
            else
            {
                string inventoryText = inventory.Replace(',', '.');
                if (double.TryParse(inventoryText, NumberStyles.Any, CultureInfo.InvariantCulture, out double inventoryValue))
                {
                    parameters.Add(new SqlParameter("@Iventory", inventoryValue));
                }
                else
                {
                    throw new FormatException("Giá trị 'Tồn kho' không hợp lệ.");
                }
            }

            // Xử lý ngày hết hạn
            if (string.IsNullOrWhiteSpace(expiryDate))
            {
                parameters.Add(new SqlParameter("@ExpiryDate", DBNull.Value));
            }
            else
            {
                if (DateTime.TryParse(expiryDate, out DateTime expiryDateValue))
                {
                    parameters.Add(new SqlParameter("@ExpiryDate", expiryDateValue));
                }
                else
                {
                    throw new FormatException("Định dạng 'Ngày hết hạn' không hợp lệ.");
                }
            }

            return db.ExecuteNonQuery(query, parameters.ToArray());
        }

        public int DeleteMedication(string id)
        {
            // Kiểm tra và chuyển đổi ID
            if (!Guid.TryParse(id, out Guid medicationId))
            {
                throw new FormatException("ID không hợp lệ. ID phải là một GUID hợp lệ.");
            }

            string query = "DELETE FROM SanPham WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", medicationId) };
            return db.ExecuteNonQuery(query, parameters);
        }

        public DataTable PickUpData()
        {
            string strSQL = "select MedicationName,MedicationType,MedicationPrice,MedicationQuantity from medication";
            return db.Execute(strSQL);
        }
    }
}
