using BookModels.Constants;
using System.Data.SqlClient;

namespace BookDAL {

    public class BookShelfSlotService {

        // 根据SlotId获取书架格子信息
        public static SqlDataReader GetSlotById(int slotId) {
            string sql = $@"SELECT * FROM {BookShelfSlotTableFields.TableName}
                           WHERE {BookShelfSlotTableFields.SlotId} = @SlotId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SlotId", slotId)
            };

            return DBHelper.ExecuteReader(sql, parameters);
        }

        // 根据SlotCode获取书架格子信息
        public static SqlDataReader GetSlotByCode(string slotCode) {
            string sql = $@"SELECT * FROM {BookShelfSlotTableFields.TableName}
                           WHERE {BookShelfSlotTableFields.SlotCode} = @SlotCode";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SlotCode", slotCode)
            };

            return DBHelper.ExecuteReader(sql, parameters);
        }

        /// 获取所有书架格子信息
        public static SqlDataReader GetAllSlots() {
            string sql = $@"SELECT * FROM {BookShelfSlotTableFields.TableName}
                           ORDER BY {BookShelfSlotTableFields.Floor},
                                    {BookShelfSlotTableFields.RowNumber},
                                    {BookShelfSlotTableFields.ColumnNumber},
                                    {BookShelfSlotTableFields.Face},
                                    {BookShelfSlotTableFields.Level}";

            return DBHelper.ExecuteReader(sql);
        }
    }
}