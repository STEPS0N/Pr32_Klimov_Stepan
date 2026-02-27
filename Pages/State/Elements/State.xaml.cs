using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VinylRecordsApplication_Klimov.Pages.State.Elements
{
    /// <summary>
    /// Логика взаимодействия для State.xaml
    /// </summary>
    public partial class State : UserControl
    {
        Classes.State state;
        Main main;

        public State(Classes.State state, Main main)
        {
            InitializeComponent();
            this.state = state;
            this.main = main;

            tbName.Text = this.state.Name;
            tbDescription.Text = this.state.Description;
            tbSubname.Text = this.state.SubName;
        }

        private void EditState(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPage(new Add(state));
        }

        private void DeleteState(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Удалить состояние: {this.state.Name}?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                IEnumerable<Classes.Record> AllRecord = Classes.Record.AllRecords();

                if (AllRecord.Where (x => x.IdState == state.Id).Count() > 0)
                {
                    MessageBox.Show($"Сщстояние {this.state.Name} невозможно удалить. Для начала удалите зависимости.", "Уведомление");
                }
                else
                {
                    this.state.Delete();
                    main.stateParent.Children.Remove(this);
                    MessageBox.Show($"Состояние {this.state.Name} успешно удалена.", "Уведомление");
                }
            }
        }
    }
}
