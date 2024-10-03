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



namespace TaskApp
{
    public partial class MainWindow : Window
    {
        // Делегат для задач
        public delegate void TaskDelegate(string taskDescription);

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод для отправки уведомления
        public static void SendNotification(string task)
        {
            MessageBox.Show($"Уведомление отправлено: {task}");
        }

        // Метод для записи задачи в журнал
        public static void LogTask(string task)
        {
            MessageBox.Show($"Задача записана в журнал: {task}");
        }

        // Обработчик нажатия на кнопку "Добавить задачу"
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskDescription = TaskTextBox.Text;

            if (string.IsNullOrEmpty(taskDescription))
            {
                ResultTextBlock.Text = "Введите описание задачи.";
                return;
            }

            // Получаем выбранное действие
            ComboBoxItem selectedAction = (ComboBoxItem)ActionComboBox.SelectedItem;
            if (selectedAction == null)
            {
                ResultTextBlock.Text = "Выберите действие для задачи.";
                return;
            }

            TaskDelegate taskDelegate;

            // Назначаем делегат в зависимости от выбора пользователя
            if (selectedAction.Content.ToString() == "Отправить уведомление")
            {
                taskDelegate = SendNotification;
            }
            else if (selectedAction.Content.ToString() == "Записать в журнал")
            {
                taskDelegate = LogTask;
            }
            else
            {
                ResultTextBlock.Text = "Ошибка выбора действия.";
                return;
            }

            // Выполнение задачи через делегат
            taskDelegate(taskDescription);
        }
    }
}
