using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_ManagementSystem
{
    public partial class InventoryManager : Form
    {

        DataTable inventory = new DataTable();
        public InventoryManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //in this part of the code we will save value from our fields intovariables

            String sku = skuTextBox.Text;
            String name = NameTextBox.Text;
            String price = PriceTextBox.Text;
            String quantity = quantityTextBox.Text;
            String description = DescriptionTextBox.Text;
            String category = (string)CategoryBox.SelectedItem;

            //after creating the necesarry variables we will now insert all the values into datatable
            inventory.Rows.Add(sku, category, price, description, quantity);

            //in order to clear the fields 
            newButton_Click(sender , e);    


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = "";
            NameTextBox.Text = "";
            PriceTextBox.Text = "";
            DescriptionTextBox.Text = "";
            quantityTextBox.Text = "";
            CategoryBox.SelectedIndex = -1;
           

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {

                Console.WriteLine("Error: "+ err);
            }
        }

        private void inventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                NameTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                PriceTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                DescriptionTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                CategoryBox.SelectedIndex = CategoryBox.Items.IndexOf(itemToLookFor);
            }
            catch ( Exception err)
            {

                Console.WriteLine("There Has Been An Error " + err);
            }

        }

        private void InventoryManager_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventory;
        }

        private void skuTextBox_Click(object sender, EventArgs e)
        {

        }

       private void CategoryBox_Click (object sender, EventArgs e) 
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
