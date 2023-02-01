using PolandDelivery.Interfaces;
using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System;

namespace PolandDelivery.Models
{
    public class UserFormsModel : IUserForms
    {
        private IDBOperationRepository _dbHelper;

        public UserFormsModel(IDBOperationRepository dbHelper) => _dbHelper = dbHelper;

        public ApiResult SendCallbackRequest(CallbackRequest input)
        {
            Callback callback = new Callback()
            {
                CreatedDate = DateTime.Now,
                Email = input.email,
                Message = input.message,
                Name = input.name,
                Phone = input.phone,
                WasAnswer = false
            };
            var sqlQuery = @"INSERT INTO Callbacks (
                                         Name,
                                         Email,
                                         Phone,
                                         Message,
                                         WasAnswer,
                                         CreatedDate
                                     )
                                     VALUES(
                                         @Name,
                                         @Email,
                                         @Phone,
                                         @Message,
                                         @WasAnswer,
                                         @CreatedDate
                                     )";
            return new ApiResult(_dbHelper.Execute(sqlQuery, callback));
        }

        public ApiResult SendMailingRequest(MailingRequest input)
        {
            Mailing mailing = new Mailing()
            {
                CreatedDate = DateTime.Now,
                Email = input.email
            };
            var sqlQuery = @"INSERT INTO Mailings (
                                         Email,
                                         CreatedDate
                                     )
                                     VALUES(
                                         @Email,
                                         @CreatedDate
                                     )";
            return new ApiResult(_dbHelper.Execute(sqlQuery, mailing));
        }
    }
}
