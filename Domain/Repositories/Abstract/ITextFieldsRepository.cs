using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;

namespace ShopWebApp.Domain.Repositories.Abstract
{
    // Интерфейс класса для взаимодействие с БД
    // Реализация интерфейса в EntityFramework
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeword(string codeword);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
