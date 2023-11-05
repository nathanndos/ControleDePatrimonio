using Patrimonio.ConstantManager;
using System;
using System.Windows.Controls;
namespace Patrimonio.Util;

public static class FormExtensions
{
    public static T getSelectItem<T>(this DataGrid dataGrid)
    {

        if (dataGrid.SelectedItem is null)
            throw new Exception(CommonExceptionConstant.SelecioneUmRegistro);

        return (T)dataGrid.SelectedItem;
    }

    public static DateTime getDateTimeFormat(this DatePicker value) => DateTime.Parse(value.Text);
    public static void setExceptionMessage(this Label value, Exception ex) => value.Content = ex.Message;
    public static void resetContent(this Label value) => value.Content = string.Empty;
    public static void setMessage(this Label value, string text) => value.Content = text;
}
