namespace ClientRepository
{
    using Microsoft.Data.SqlClient;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

    public partial class Form1 : Form
    {
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
        //make blank variables

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
        private void button1_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(getName.Text) || string.IsNullOrWhiteSpace(getHouse.Text) || string.IsNullOrWhiteSpace(getTown.Text) || string.IsNullOrWhiteSpace(getCounty.Text) || string.IsNullOrWhiteSpace(getPostcode.Text) || string.IsNullOrWhiteSpace(getEmail.Text) || string.IsNullOrWhiteSpace(phoneText))
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

            //make new address and client objects
            address = new Address(House, Town, County, Postcode);
            client = new Client(null, name, address, PhoneNumber, Email, categories);

            
            //Category celection check 
            bool software = CheckedListBoxCategories.GetItemChecked(0);
            bool laptop = CheckedListBoxCategories.GetItemChecked(1);
            bool games = CheckedListBoxCategories.GetItemChecked(2);
            bool office = CheckedListBoxCategories.GetItemChecked(3);
            bool accessories = CheckedListBoxCategories.GetItemChecked(4);

            


            //Add details to database
            int cat_id = Cat.addToDB(software, laptop, games, office, accessories);
            int address_id = Address.addToDB(House, Town, County, Postcode);
            Client.addToDB(address_id, cat_id, name, PhoneNumber, Email);
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

     }

 }
    

