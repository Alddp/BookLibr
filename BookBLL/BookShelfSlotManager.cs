using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Constants;
using BookModels.Errors;
using System.Collections.Generic;
using static BookModels.Errors.ErrorMessages;

namespace BookBLL {

    public class BookShelfSlotManager {

        // 根据SlotId获取书架格子信息
        public static OperationResult<BookShelfSlot> GetSlotById(int slotId) {
            var res = ResultWrapper.Wrap(() => {
                using (var reader = BookShelfSlotService.GetSlotById(slotId)) {
                    if (reader.Read()) {
                        return new BookShelfSlot {
                            SlotId = (int)reader[BookShelfSlotTableFields.SlotId],
                            Floor = (int)reader[BookShelfSlotTableFields.Floor],
                            RowNumber = (int)reader[BookShelfSlotTableFields.RowNumber],
                            ColumnNumber = (int)reader[BookShelfSlotTableFields.ColumnNumber],
                            Face = reader[BookShelfSlotTableFields.Face].ToString(),
                            Level = (int)reader[BookShelfSlotTableFields.Level],
                            SlotCode = reader[BookShelfSlotTableFields.SlotCode].ToString(),
                            Location = reader[BookShelfSlotTableFields.Location].ToString()
                        };
                    }
                    return null;
                }
            });

            return res.Success
                ? res.Data != null ? res : OperationResult<BookShelfSlot>.Fail(ErrorCode.SlotNotFound)
                : OperationResult<BookShelfSlot>.Fail(
                    ErrorCode.SlotQueryFailed,
                    GetMessage(ErrorCode.SlotQueryFailed, res.Message));
        }

        //根据SlotCode获取书架格子信息
        public static OperationResult<BookShelfSlot> GetSlotByCode(string slotCode) {
            if (string.IsNullOrWhiteSpace(slotCode)) {
                return OperationResult<BookShelfSlot>.Fail(ErrorCode.InvalidParameter, "格子编码不能为空");
            }

            var res = ResultWrapper.Wrap(() => {
                using (var reader = BookShelfSlotService.GetSlotByCode(slotCode)) {
                    if (reader.Read()) {
                        return new BookShelfSlot {
                            SlotId = (int)reader[BookShelfSlotTableFields.SlotId],
                            Floor = (int)reader[BookShelfSlotTableFields.Floor],
                            RowNumber = (int)reader[BookShelfSlotTableFields.RowNumber],
                            ColumnNumber = (int)reader[BookShelfSlotTableFields.ColumnNumber],
                            Face = reader[BookShelfSlotTableFields.Face].ToString(),
                            Level = (int)reader[BookShelfSlotTableFields.Level],
                            SlotCode = reader[BookShelfSlotTableFields.SlotCode].ToString(),
                            Location = reader[BookShelfSlotTableFields.Location].ToString()
                        };
                    }
                    return null;
                }
            });

            return res.Success
                ? res.Data != null ? res : OperationResult<BookShelfSlot>.Fail(ErrorCode.SlotNotFound)
                : OperationResult<BookShelfSlot>.Fail(
                    ErrorCode.SlotQueryFailed,
                    GetMessage(ErrorCode.SlotQueryFailed, res.Message));
        }

        // 获取所有书架格子信息
        public static OperationResult<List<BookShelfSlot>> GetAllSlots() {
            var res = ResultWrapper.Wrap(() => {
                var slots = new List<BookShelfSlot>();
                using (var reader = BookShelfSlotService.GetAllSlots()) {
                    while (reader.Read()) {
                        slots.Add(new BookShelfSlot {
                            SlotId = (int)reader[BookShelfSlotTableFields.SlotId],
                            Floor = (int)reader[BookShelfSlotTableFields.Floor],
                            RowNumber = (int)reader[BookShelfSlotTableFields.RowNumber],
                            ColumnNumber = (int)reader[BookShelfSlotTableFields.ColumnNumber],
                            Face = reader[BookShelfSlotTableFields.Face].ToString(),
                            Level = (int)reader[BookShelfSlotTableFields.Level],
                            SlotCode = reader[BookShelfSlotTableFields.SlotCode].ToString(),
                            Location = reader[BookShelfSlotTableFields.Location].ToString()
                        });
                    }
                }
                return slots;
            });

            return res.Success
                ? res
                : OperationResult<List<BookShelfSlot>>.Fail(
                    ErrorCode.SlotQueryFailed,
                    GetMessage(ErrorCode.SlotQueryFailed, res.Message));
        }
    }
}