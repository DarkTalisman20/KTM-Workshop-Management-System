namespace dbproject
{
    public partial class Form1 : Form
    {
        BindingSource aicbindingSource = new BindingSource();
        BindingSource areabindingSource = new BindingSource();
        BindingSource workshopbindingSource = new BindingSource();
        BindingSource workshopICbindingSource = new BindingSource();
        BindingSource managesbindingSource = new BindingSource();
        BindingSource revenuebindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            aicbindingSource.DataSource = aICdao.getAllAICs();

            dataGridView1.DataSource = aicbindingSource;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            aicbindingSource.DataSource = aICdao.searchName(textBox1.Text);

            dataGridView1.DataSource = aicbindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AIC aic = new AIC
            {
                ID = Int32.Parse(idtext.Text),
                FirstName = fnametext.Text,
                MiddleName = mnametext.Text,
                LastName = lnametext.Text
            };

            AICdao aICdao = new AICdao();
            int result = aICdao.addentry(aic);

            aicbindingSource.DataSource = aICdao.getAllAICs();
            dataGridView1.DataSource = aicbindingSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            AICdao aICdao = new AICdao();
            int rowClicked = dataGridView1.CurrentRow.Index;
            areabindingSource.DataSource = aICdao.areabyic((int)dataGridView1.Rows[rowClicked].Cells[0].Value);

            dataGridView2.DataSource = areabindingSource;


            workshopICbindingSource.DataSource = aICdao.WorkshopICbyAreaIC((int)dataGridView1.Rows[rowClicked].Cells[0].Value);

            dataGridView4.DataSource = workshopICbindingSource;

            // Get the selected row
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Fill the text boxes with the values from the selected row
            idtext.Text = row.Cells["ID"].Value.ToString();
            fnametext.Text = row.Cells["FirstName"].Value.ToString();
            mnametext.Text = row.Cells["MiddleName"].Value.ToString();
            lnametext.Text = row.Cells["LastName"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            areabindingSource.DataSource = aICdao.getAllAreas();

            dataGridView2.DataSource = areabindingSource;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            workshopbindingSource.DataSource = aICdao.getAllWorkshops();

            dataGridView3.DataSource = workshopbindingSource;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AICdao aICdao = new AICdao();
            int rowClicked = dataGridView2.CurrentRow.Index;
            workshopbindingSource.DataSource = aICdao.workshopbyarea(dataGridView2.Rows[rowClicked].Cells[0].Value.ToString());
            dataGridView3.DataSource = workshopbindingSource;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            workshopbindingSource.DataSource = aICdao.searchWorkshop(textBox2.Text);

            dataGridView3.DataSource = workshopbindingSource;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Workshop workshop = new Workshop
            {
                wkCode = Int32.Parse(textBox3.Text),
                wkName = textBox4.Text,
                wkArea = textBox5.Text,
                manpower = Int32.Parse(textBox6.Text),
                customer_visits = Int32.Parse(textBox7.Text),
                recovery = textBox8.Text,
                score = Int32.Parse(textBox9.Text)
            };

            AICdao aICdao = new AICdao();
            int result = aICdao.addWorkshop(workshop);
            workshopbindingSource.DataSource = aICdao.getAllWorkshops();
            dataGridView3.DataSource = workshopbindingSource;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            workshopICbindingSource.DataSource = aICdao.getAllWorkshopICs();

            dataGridView4.DataSource = workshopICbindingSource;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            workshopICbindingSource.DataSource = aICdao.searchWorkshopIC(textBox17.Text);

            dataGridView3.DataSource = workshopbindingSource;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            WorkshopIC workshopIC = new WorkshopIC
            {
                WkICID = Int32.Parse(textBox16.Text),
                FName = textBox15.Text,
                MName = textBox14.Text,
                LName = textBox13.Text,
                Rating = Int32.Parse(textBox12.Text),
                AreaIC = Int32.Parse(textBox11.Text),
            };

            AICdao aICdao = new AICdao();
            int result = aICdao.addWorkshopIC(workshopIC);
            workshopICbindingSource.DataSource = aICdao.getAllWorkshopICs();
            dataGridView4.DataSource = workshopICbindingSource;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            managesbindingSource.DataSource = aICdao.getAllManages();

            dataGridView5.DataSource = managesbindingSource;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Manages manages = new Manages
            {
                WkshpID = Int32.Parse(textBox26.Text),
                ICID = Int32.Parse(textBox25.Text)
            };

            AICdao aICdao = new AICdao();
            int result = aICdao.addManages(manages);

            managesbindingSource.DataSource = aICdao.getAllManages();
            dataGridView5.DataSource = managesbindingSource;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AICdao aICdao = new AICdao();
            int rowClicked = dataGridView4.CurrentRow.Index;
            managesbindingSource.DataSource = aICdao.managesbyic((int)dataGridView4.Rows[rowClicked].Cells[0].Value);
            dataGridView5.DataSource = managesbindingSource;

            // Get the selected row
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

            // Fill the text boxes with the values from the selected row
            textBox16.Text = row.Cells["WkICID"].Value.ToString();
            textBox15.Text = row.Cells["FName"].Value.ToString();
            textBox14.Text = row.Cells["MName"].Value.ToString();
            textBox13.Text = row.Cells["LName"].Value.ToString();
            textBox12.Text = row.Cells["Rating"].Value.ToString();
            textBox11.Text = row.Cells["AreaIC"].Value.ToString();
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            AICdao aICdao = new AICdao();

            revenuebindingSource.DataSource = aICdao.getallrevenues();

            dataGridView6.DataSource = revenuebindingSource;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            revenue revenue = new revenue
            {
                wkcode = Int32.Parse(textBox24.Text),
                year = Int32.Parse(textBox27.Text),
                quarter = Int32.Parse(textBox28.Text),
                total_sales = Int32.Parse(textBox29.Text),
                service_cost = Int32.Parse(textBox30.Text),
                profit = Int32.Parse(textBox31.Text),
            };

            AICdao aICdao = new AICdao();
            int result = aICdao.addrevenues(revenue);
            revenuebindingSource.DataSource = aICdao.getallrevenues();
            dataGridView6.DataSource = revenuebindingSource;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AICdao aICdao = new AICdao();
            int rowClicked = dataGridView3.CurrentRow.Index;
            managesbindingSource.DataSource = aICdao.managesbyworkshop((int)dataGridView3.Rows[rowClicked].Cells[0].Value);
            revenuebindingSource.DataSource = aICdao.revenuebyworkshop((int)dataGridView3.Rows[rowClicked].Cells[0].Value);
            dataGridView5.DataSource = managesbindingSource;
            dataGridView6.DataSource = revenuebindingSource;

            // Get the selected row
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];

            // Fill the text boxes with the values from the selected row
            textBox3.Text = row.Cells["wkCode"].Value.ToString();
            textBox4.Text = row.Cells["wkName"].Value.ToString();
            textBox5.Text = row.Cells["wkArea"].Value.ToString();
            textBox6.Text = row.Cells["manpower"].Value.ToString();
            textBox7.Text = row.Cells["customer_visits"].Value.ToString();
            textBox8.Text = row.Cells["recovery"].Value.ToString();
            textBox9.Text = row.Cells["score"].Value.ToString();
        }

        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            AICdao aICdao = new AICdao();
            int rowClicked = dataGridView5.CurrentRow.Index;
            revenuebindingSource.DataSource = aICdao.revenuebyworkshop((int)dataGridView5.Rows[rowClicked].Cells[0].Value);
            dataGridView6.DataSource = revenuebindingSource;
        }


        private void button15_Click(object sender, EventArgs e)
        {
            // Check if all text boxes contain valid integer values
            if (!int.TryParse(textBox24.Text, out int wkcode) ||
            !int.TryParse(textBox27.Text, out int year) ||
            !int.TryParse(textBox28.Text, out int quarter) ||
            !int.TryParse(textBox29.Text, out int total_sales) ||
            !int.TryParse(textBox30.Text, out int service_cost) ||
            !int.TryParse(textBox31.Text, out int profit))
            {
                // One of the text boxes does not contain a valid integer value, show an error message
                MessageBox.Show("Please enter valid integer values.");
                return;
            }
            // Create a new revenue object with the updated values
            revenue updatedRevenue = new revenue
            {
                wkcode = wkcode,
                year = year,
                quarter = quarter,
                total_sales = total_sales,
                service_cost = service_cost,
                profit = profit,
            };

            // Create a new AICdao object
            AICdao aICdao = new AICdao();

            // Call the updateRevenue method
            int result = aICdao.updateRevenue(updatedRevenue, updatedRevenue.wkcode);

            // Check if the update was successful
            if (result > 0)
            {
                // The update was successful, refresh the DataGridView
                revenuebindingSource.DataSource = aICdao.getallrevenues();
                dataGridView6.DataSource = revenuebindingSource;
            }
            else
            {
                // The update failed, show an error message
                MessageBox.Show("Update failed.");
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow row = dataGridView6.Rows[e.RowIndex];

            // Fill the text boxes with the values from the selected row
            textBox24.Text = row.Cells["wkcode"].Value.ToString();
            textBox27.Text = row.Cells["year"].Value.ToString();
            textBox28.Text = row.Cells["quarter"].Value.ToString();
            textBox29.Text = row.Cells["total_sales"].Value.ToString();
            textBox30.Text = row.Cells["service_cost"].Value.ToString();
            textBox31.Text = row.Cells["profit"].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView6.CurrentRow.Index;
            int revenueID = (int)dataGridView6.Rows[rowClicked].Cells[0].Value;
            int revenueyear = (int)dataGridView6.Rows[rowClicked].Cells[1].Value;
            int revenuequarter = (int)dataGridView6.Rows[rowClicked].Cells[2].Value;
            AICdao aicdao = new AICdao();
            int result = aicdao.deleterevenue(revenueID, revenueyear, revenuequarter);

            revenuebindingSource.DataSource = aicdao.getallrevenues();
            dataGridView6.DataSource = revenuebindingSource;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView3.CurrentRow.Index;
            int wkid = (int)dataGridView3.Rows[rowClicked].Cells[0].Value;
            AICdao aicdao = new AICdao();
            int result = aicdao.deleteworkshop(wkid);

            workshopbindingSource.DataSource = aicdao.getAllWorkshops();
            dataGridView3.DataSource = workshopbindingSource;
            managesbindingSource.DataSource = aicdao.getAllManages();
            dataGridView5.DataSource = managesbindingSource;
            revenuebindingSource.DataSource = aicdao.getallrevenues();
            dataGridView6.DataSource = revenuebindingSource;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int rowClicked = dataGridView4.CurrentRow.Index;
            int wkic = (int)dataGridView4.Rows[rowClicked].Cells[0].Value;
            AICdao aicdao = new AICdao();
            int result = aicdao.deletewkshpic(wkic);

            workshopICbindingSource.DataSource = aicdao.getAllWorkshopICs();
            dataGridView4.DataSource = workshopICbindingSource;

            managesbindingSource.DataSource = aicdao.getAllManages();
            dataGridView5.DataSource = managesbindingSource;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            // Create a new revenue object with the updated values
            AIC updatedAIC = new AIC
            {
                ID = int.Parse(idtext.Text),
                FirstName = fnametext.Text,
                MiddleName = mnametext.Text,
                LastName = lnametext.Text
            };

            // Create a new AICdao object
            AICdao aICdao = new AICdao();

            // Call the updateRevenue method
            int result = aICdao.updateAICs(updatedAIC, updatedAIC.ID);

            // Check if the update was successful
            if (result > 0)
            {
                // The update was successful, refresh the DataGridView
                aicbindingSource.DataSource = aICdao.getAllAICs();
                dataGridView1.DataSource = aicbindingSource;
            }
            else
            {
                // The update failed, show an error message
                MessageBox.Show("Update failed.");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // Create a new revenue object with the updated values
            Workshop updatedWkshp = new Workshop
            {
                wkCode = int.Parse(textBox3.Text),
                wkName = textBox4.Text,
                wkArea = textBox5.Text,
                manpower = int.Parse(textBox6.Text),
                customer_visits = int.Parse(textBox7.Text),
                recovery = textBox8.Text,
                score = int.Parse(textBox9.Text)
            };

            // Create a new AICdao object
            AICdao aICdao = new AICdao();

            // Call the updateRevenue method
            int result = aICdao.updateWkshp(updatedWkshp, updatedWkshp.wkCode);

            // Check if the update was successful
            if (result > 0)
            {
                // The update was successful, refresh the DataGridView
                workshopbindingSource.DataSource = aICdao.getAllWorkshops();
                dataGridView3.DataSource = workshopbindingSource;
            }
            else
            {
                // The update failed, show an error message
                MessageBox.Show("Update failed.");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            WorkshopIC updatedwkshpic = new WorkshopIC
            {
                WkICID = int.Parse(textBox16.Text),
                FName = textBox15.Text,
                MName = textBox14.Text,
                LName = textBox13.Text,
                Rating = int.Parse(textBox12.Text),
                AreaIC = int.Parse(textBox11.Text),
            };

            // Create a new AICdao object
            AICdao aICdao = new AICdao();

            // Call the updateRevenue method
            int result = aICdao.updateWkshpIC(updatedwkshpic, updatedwkshpic.WkICID);

            // Check if the update was successful
            if (result > 0)
            {
                // The update was successful, refresh the DataGridView
                workshopICbindingSource.DataSource = aICdao.getAllWorkshopICs();
                dataGridView4.DataSource = workshopICbindingSource;
            }
            else
            {
                // The update failed, show an error message
                MessageBox.Show("Update failed.");
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void dfj(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }
    }
}