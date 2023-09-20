using Patrimonio.ConstantManager;
using Patrimonio.Entity;
using System;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class FormExtensions
    {
        public static T getSelectItem<T>(this DataGrid dataGrid)
        {

            if (dataGrid.SelectedItem is null)
                throw new Exception(CommonExceptionConstant.SelecioneUmRegistro);

            return (T)dataGrid.SelectedItem;
        }
    }
}
