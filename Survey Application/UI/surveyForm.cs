using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;
using Survey_Application.BLL;
using Survey_Application.DAL;



namespace Survey_Application.UI
{
    public partial class surveyForm : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Survey.accdb");
        public surveyForm()
        {
            InitializeComponent();           
        }

        //Create object 
        personBLL person_BLL = new personBLL();
        personDAL person_DAL = new personDAL();

        

        eatOutBLL eatOut_BLL = new eatOutBLL();
        eatOutDAL eatOut_DAL = new eatOutDAL();
        

        movieBLL movie_BBL = new movieBLL();
        moviesDAL movie_DAL = new moviesDAL();

        tvBLL tv_BLL = new tvBLL();
        tvDAL tv_DAL = new tvDAL();

        radioBLL radio_BLL = new radioBLL();
        radioDAL radio_DAL = new radioDAL();

        resultDAL dal = new resultDAL();
        filter myfilter = new filter();


        Answer answer = new Answer();
        AnswerDAL answerdal = new AnswerDAL();
        

       
        

        private void surveyForm_Load(object sender, EventArgs e)
        {

        }
        public void addperson()
        {
            person_BLL.personSurname = txtBxName.Text;
            person_BLL.personFirstNames = txtBxFirstNames.Text;
            person_BLL.personContactNumber = txtBxContactNumber.Text;
            person_BLL.personBirthDate = bunifuDatePicker1.Value.ToString("dd MMMM yyyy");
            person_BLL.personAge = txtBxAge.Text;

            bool isSuccess = person_DAL.Insert(person_BLL);

            if (isSuccess == true)
            {
                MessageBox.Show("Thank you for take survey.");
            }
          
        }
        private string listfoods()
        {
            string strFood = "";
            if (chckBxPizza.Checked == true)
            {
                strFood = "Pizza";                               
            }
            if (chckBxPasta.Checked == true)
            {
                strFood = "Pasta";
                
            }
            if (chckBxPapAndWors.Checked == true)
            {
                strFood = "Pap and Wors";

            }
            if (chckBxChicken.Checked == true)
            {
                strFood = "Chicken stir fry";
            }
            if (chckBxBeef.Checked == true)
            {
                strFood = "Beef stir fry";               
            }
            if (chckBxOther.Checked == true)
            {
                strFood = "other";                
            }

            return strFood;
        }

        public int eatOutRate()
        {
            int rate = 0;
            
            if(radSAgreeEatOut.Checked == true)
            {
                rate = 1;
            }
            else if (radAgreeEatOut.Checked == true)
            {
                rate = 2;
            }
            else if(radSNeutralEatOut.Checked == true)
            {
                rate = 3;
            }
            else if (radDisagreeEatOut.Checked == true)
            {
                rate = 4;
            }
            else if(radSdiseEatOut.Checked == true)
            {
                rate = 5;
            }
            return rate;
        }
        /*public string eatOutStr()
        {
            string str = "";

            if (radSAgreeEatOut.Checked == true)
            {
                str = "I like to eat out";
            }
            else if (radAgreeEatOut.Checked == true)
            {
                str = "I like to eat out";
            }
            else if (radSNeutralEatOut.Checked == true)
            {
                str = "I like to eat out";
            }
            else if (radDisagreeEatOut.Checked == true)
            {
                str = "I like to eat out";
            }
            else if (radSdiseEatOut.Checked == true)
            {
                str = "I like to eat out";
            }
            return str;
        }*/
        //movies
        public int moviesRate()
        {
            int rate = 0;
            if (radStrAgrMovies.Checked == true)
            {
                rate = 1;
            }
            else if (radAgreemovies.Checked == true)
            {
                rate = 2;
            }
            else if (radNeutralmovies.Checked == true)
            {
                rate = 3;
            }
            else if (radDAgreemovies.Checked == true)
            {
                rate = 4;
            }
            else if (radStrDAgreemovies.Checked == true)
            {
                rate = 5;
            }
            return rate;
        }
        /*public string moviesStr()
        {
            string str = "";
            if (radStrAgrMovies.Checked == true)
            {
                str = "I like to watch movies";
            }
            else if (radAgreemovies.Checked == true)
            {
                str = "I like to watch movies";
            }
            else if (radNeutralmovies.Checked == true)
            {
                str = "I like to watch movies";
            }
            else if (radDAgreemovies.Checked == true)
            {
                str = "I like to watch movies";
            }
            else if (radStrDAgreemovies.Checked == true)
            {
                str = "I like to watch movies";
            }
            return str;
        }*/

        //tv
        public int tvRate()
        {
            int rate = 0;
            if (radStrAgrtv.Checked == true)
            {
                rate = 1;
            }
            else if (radAgreetv.Checked == true)
            {
                rate = 2;
            }
            else if (radNeutraltv.Checked == true)
            {
                rate = 3;
            }
            else if (radDAgreemtv.Checked == true)
            {
                rate = 4;
            }
            else if (radStrDAgreeTv.Checked == true)
            {
                rate = 5;
            }
            return rate;
        }
        /*public string tvStr()
        {
            string str = "";
            if (radStrAgrtv.Checked == true)
            {
                str = "I like to watch TV";
            }
            else if (radAgreetv.Checked == true)
            {
                str = "I like to watch TV";
            }
            else if (radNeutraltv.Checked == true)
            {
                str = "I like to watch TV";
            }
            else if (radDAgreemtv.Checked == true)
            {
                str = "I like to watch TV";
            }
            else if (radStrDAgreeTv.Checked == true)
            {
                str = "I like to watch TV";
            }
            return str;
        }*/


        //radio
        public int radioRate()
        {
           
            
           
            int rate = 0;
            if (radStrAgrradio.Checked == true)
            {
                rate = 1;
            }
            else if (radAgreeradio.Checked == true)
            {
                rate = 2;
            }
            else if (radNeutralradio.Checked == true)
            {
                rate = 3;
            }
            else if (radDAgreeradio.Checked == true)
            {
                rate = 4;
            }
            else if (radStrDAgreeradio.Checked == true)
            {
                rate = 5;
            }
            return rate;
        }
        /*public string radioStr()
        {
            string str = "";
            if (radStrAgrradio.Checked == true)
            {
                str = "I like to listen to the radio";
            }
            else if (radAgreeradio.Checked == true)
            {
                str = "I like to listen to the radio";
            }
            else if (radNeutralradio.Checked == true)
            {
                str = "I like to listen to the radio";
            }
            else if (radDAgreeradio.Checked == true)
            {
                str = "I like to listen to the radio";
            }
            else if (radStrDAgreeradio.Checked == true)
            {
                str = "I like to listen to the radio";
            }
            return str;
        }*/


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            addperson();
            // add radio
            radio_BLL.rate = radioRate();
            bool isSucces6 = radio_DAL.Insert(radio_BLL);       
 
            // add movies
            movie_BBL.rate = moviesRate();
            bool isSucces4 = movie_DAL.Insert(movie_BBL);           

            //add eat out
            eatOut_BLL.rate = eatOutRate();
            bool isSucces3 = eatOut_DAL.Insert(eatOut_BLL);          

            //tv
            tv_BLL.rate = tvRate();
            bool isSucces5 = tv_DAL.Insert(tv_BLL);

            //food answers

            string food = "";
            if(chckBxPizza.Checked == true)
            {
                food += "Pizza,";
            }
            if (chckBxPasta.Checked == true)
            {
                food += "Pasta,";
            }
            if (chckBxPapAndWors.Checked == true)
            {
                food += "Pap and Wors,";
            }
            if (chckBxChicken.Checked == true)
            {
                food += "Chicken stir fry,";
            }
            if (chckBxBeef.Checked == true)
            {
                food += "Beef stir fry,";
            }
            if (chckBxOther.Checked == true)
            {
                food += "Other,";
            }

            
            tv_BLL.rate = tvRate();
            answer.answer_text = food;
            bool isSucces9 = answerdal.Insert(answer);
            Form2 myform = new Form2();
            myform.Close();
            this.Close();
        }

        private void bunifuCheckBox5_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
          
        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
