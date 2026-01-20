namespace ClientRepository
{
    using Microsoft.Data.SqlClient;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

    public partial class Form1 : Form
    {
        private int client_id = 0;
        private int address_id = 0;
        private int cat_id = 0;

        string name;
        Address address = new Address();
        Client client = new Client();
        string House;
        string Town;
        string County;
        string Postcode;
        string PhoneNumber;
        string Email;
        List<Cat> categories = new List<Cat>();
        public Form1()
        {
            InitializeComponent();

            
            // Ensure categories always has five entries (all unselected by default)
            categories = new List<Cat>
            {
                new Cat(false, Cat.Category.Software),
                new Cat(false, Cat.Category.Laptop_PCs),
                new Cat(false, Cat.Category.Games),
                new Cat(false, Cat.Category.Office_Tools),
                new Cat(false, Cat.Category.Accessories),
            };
        }

        public Form1(int client_id, string name, string House, string Town, string County, string Postcode, string PhoneNumber, string Email, bool software, bool laptop, bool games, bool office, bool accessories)
        {
            InitializeComponent();
            getName.Text = name;
            getHouse.Text = House;
            getTown.Text = Town;
            getCounty.Text = County;
            getPostcode.Text = Postcode;
            getphone.Text = PhoneNumber;
            getEmail.Text = Email;

            this.client_id = client_id;
            this.address_id = address_id;
            this.cat_id = cat_id;

            CheckedListBoxCategories.SetItemChecked(0, software);
            CheckedListBoxCategories.SetItemChecked(1, laptop);
            CheckedListBoxCategories.SetItemChecked(2, games);
            CheckedListBoxCategories.SetItemChecked(3, office);
            CheckedListBoxCategories.SetItemChecked(4, accessories);
        }

      






    private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(getName.Text) || string.IsNullOrWhiteSpace(getHouse.Text) || string.IsNullOrWhiteSpace(getTown.Text) || string.IsNullOrWhiteSpace(getCounty.Text) || string.IsNullOrWhiteSpace(getPostcode.Text) || string.IsNullOrWhiteSpace(getEmail.Text) || string.IsNullOrWhiteSpace(getphone.Text))
            {

                MessageBox.Show("All attributes must be filled in!", "Warning", MessageBoxButtons.OK);
                return;
            }

            string phoneText = getphone.Text.Trim();



            name = getName.Text.Trim();
            House = getHouse.Text.Trim();
            Town = getTown.Text.Trim();
            County = getCounty.Text.Trim();
            Postcode = getPostcode.Text.Trim();
            Email = getEmail.Text;
            PhoneNumber = phoneText;

  


            //Category celection check 
            bool software = CheckedListBoxCategories.GetItemChecked(0);
            bool laptop = CheckedListBoxCategories.GetItemChecked(1);
            bool games = CheckedListBoxCategories.GetItemChecked(2);
            bool office = CheckedListBoxCategories.GetItemChecked(3);
            bool accessories = CheckedListBoxCategories.GetItemChecked(4);

            categories.Clear();
            categories.Add(new Cat(software, category.Software));
            categories.Add(new Cat(laptop, category.Laptop_PCs));
            categories.Add(new Cat(games, category.Games));
            categories.Add(new Cat(office, category.Office_Tools));
            categories.Add(new Cat(accessories, category.Accessories));

            //make new address and client objects
            

                //if client_id == null then add new client to database
                if (client_id == 0)
            {
                this.cat_id = Cat.addToDB(software, laptop, games, office, accessories);
                this.address_id = Address.addToDB(House, Town, County, Postcode);
                Client.addToDB(this.address_id, this.cat_id, name, PhoneNumber, Email);
                MessageBox.Show("New client added successfully!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                Cat.updateInDB(this.cat_id, software, laptop, games, office, accessories);
                Address.updateInDB(this.address_id, House, Town, County, Postcode);
                Client.updateInDB(this.client_id, this.address_id, this.cat_id, name, PhoneNumber, Email);
                MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK);
            }
        }
        public enum category
        {
            Software,
            Laptop_PCs,
            Games,
            Office_Tools,
            Accessories
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            bool Software_Select = CheckedListBoxCategories.GetItemChecked(0);
            category software_attr_2 = category.Software;
            Cat Software = new Cat(Software_Select, software_attr_2);

            bool Laptop_PCs_Select = CheckedListBoxCategories.GetItemChecked(1);
            category Laptop_PCs_attr_2 = category.Laptop_PCs;
            Cat Laptop_PCs = new Cat(Laptop_PCs_Select, Laptop_PCs_attr_2);


            bool Games_Select = CheckedListBoxCategories.GetItemChecked(2);
            category Games_attr_2 = category.Games;
            Cat Games = new Cat(Games_Select, Games_attr_2);

            bool Office_Tools_Select = CheckedListBoxCategories.GetItemChecked(3);
            category Office_Tools_attr_2 = category.Office_Tools;
            Cat Office_Tools = new Cat(Office_Tools_Select, Office_Tools_attr_2);

            bool Accessories_Select = CheckedListBoxCategories.GetItemChecked(4);
            category Accessories_attr_2 = category.Accessories;
            Cat Accessories = new Cat(Accessories_Select, Accessories_attr_2);

            categories.Clear();
            categories.Add(Software);
            categories.Add(Laptop_PCs);
            categories.Add(Games);
            categories.Add(Office_Tools);
            categories.Add(Accessories);

        }



        private void getName_TextChanged(object sender, EventArgs e)
        {

            name = getName.Text;
        }

        private void getHouse_TextChanged(object sender, EventArgs e)
        {
            House = getHouse.Text;
        }

        private void getTown_TextChanged(object sender, EventArgs e)
        {
            Town = getTown.Text;
        }

        private void getCounty_TextChanged(object sender, EventArgs e)
        {
            County = getCounty.Text;
        }

        private void getPostcode_TextChanged(object sender, EventArgs e)
        {
            Postcode = getPostcode.Text;
        }

        private void getEmail_TextChanged(object sender, EventArgs e)
        {
            Email = getEmail.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            //close form1
            
        }
    }
}
    

