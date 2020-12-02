using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Telephon.Models.shapka;

namespace Telephon.Views
{
    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            FrameworkElement element = container as FrameworkElement;
            if (item != null)
            {


                //в зависимости от того, какой вариант выбран, возвращаем конкретный шаблон
                if (((FieldSection)item).tip == "string")
                    return element.FindResource("StringTemplate") as DataTemplate;
                if (((FieldSection)item).tip == "obj2")
                    return element.FindResource("ButtonTemplate2") as DataTemplate;
                if (((FieldSection)item).tip == "obj1")
                    return element.FindResource("ButtonTemplate1") as DataTemplate;
                if (((FieldSection)item).tip == "bool")
                    return element.FindResource("CheckBoxTemplate") as DataTemplate;
                if (((FieldSection)item).tip == "time.Time")
                    return element.FindResource("DateTemplate") as DataTemplate;
            }
            return null;
        }
    }
    /// <summary>
    /// Логика взаимодействия для shapka.xaml
    /// </summary>
    public partial class VUC_shapka : UserControl
    {
        public VUC_shapka()
        {
            InitializeComponent();
        }
    }
}
