using Business_Layer;
using System;
using System.Windows.Forms;
using TODO_List.Objects;

namespace TODO_List
{
    public partial class Form1 : Form
    {
        public static Items items = new Items();
        private Item currentItem;
       
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            items.itemList = Actions.LoadData<Item>(); ;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = items.itemList;

            comboBox1.DataSource = items.itemList;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }

        private void buttonCreateNewTask_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ItemsUpdated += Form1_Load;
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doneButton.Enabled = comboBox1.SelectedIndex == -1 ? false : true;
            saveButton.Enabled = false;
            currentItem = (Item)comboBox1.SelectedItem;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (saveButton.Enabled != true)
            {
                currentItem = (Item)comboBox1.SelectedItem;
                if (comboBox1.Text != currentItem.Name) saveButton.Enabled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {            
            currentItem.Name = comboBox1.Text;            
            Actions.SaveData(Form1.items.itemList);
            Form1_Load(sender, e);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if(currentItem == null) currentItem = (Item)comboBox1.SelectedItem;
            currentItem.IsDone = true;
            Actions.SaveData(Form1.items.itemList);
            Form1_Load(sender, e);
        }
    }
}
