using System;
using System.Windows.Forms;
using TODO_List.Objects;
using TODO_List.Utils;

namespace TODO_List
{
    public partial class Form2 : Form
    {
        public event EventHandler<EventArgs> ItemsUpdated;

        public Form2()
        {
            InitializeComponent();
        }

        private void ClickOk(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNewTask.Text))
            {
                //TODO add show error message to the user
                return;
            }

            var newTask = new Item
            {
                Name = textBoxNewTask.Text,
                IsDone = false,
                Id = Form1.items.GetMaxId() + 1
            };

            Form1.items.itemList.Add(newTask);
            WorkWithFile.TaskListToJson(Form1.items, @"D:\Sneghka\IT\Visual Studio\TODO List\Tasks.json");
            this.Close();
            ItemsUpdated?.Invoke(this, e);
        }
       
    }
}
