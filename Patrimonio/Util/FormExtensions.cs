using Patrimonio.ConstantManager;
using System;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class FormExtensions
    {
        public static T getSelectItem<T>(this DataGrid dataGrid)
        {
            if (dataGrid.SelectedItem is null)
                throw new Exception(CommonExceptionMessage.SelecioneUmRegistro);

            return (T)dataGrid.SelectedItem;
        }
    }
}
