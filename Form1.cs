using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace secindTry
{
    public partial class Form1 : Form
    {
       static string[] tr =
        { "adana", "adiyaman", "afyonkarahisar", "agri", "aksaray", "amasya", "ankara",
            "antalya", "ardahan", "artvin", "aydin", "balikesir", "bartin", "batman",
            "bayburt", "bilecik", "bingol", "bitlis", "bolu", "burdur", "bursa",
            "canakkale", "cankiri", "corum", "denizli", "diyarbakir", "duzce",
            "edirne", "elazig", "erzincan", "erzurum", "eskisehir", "gaziantep",
            "giresun", "gumushane", "hakkari", "hatay", "igdir", "isparta", "istanbul",
            "izmir", "kahramanmaras", "karabuk", "karaman", "kars", "kastamonu",
            "kayseri", "kirikkale", "kirklareli", "kirsehir", "kilis", "kocaeli",
            "konya", "kutahya", "malatya", "manisa", "mardin", "mersin", "mugla",
            "mus", "nevsehir", "nigde", "ordu", "osmaniye", "rize", "sakarya", "samsun",
            "sanliurfa", "siirt", "sinop", "sivas", "sirnak", "tekirdag", "tokat",
            "trabzon", "tunceli", "usak", "van", "yalova", "yozgat", "zonguldak"};
       
        static  string string_word;                                      //the word
        static int rnd;                                                  //random number
        static int scoreP_1 = 0;
        static int scoreP_2 = 0;
        static bool turn = true;                                         //true bool is for 1 player false bool is for 2 player . will start with 1 player
        static  string secret_string_word;                               //the word as secre word
        static  char[] secret_word;                                      //the secret word as char array 
        static char letter;                                              // the letter that we got from user
        static int HEALTH = 7;          
        
        Random random = new Random(); 
        public Form1()
        { this.BackgroundImage= Image.FromFile("frames\\hangman_1.png");                 //set default image 
            InitializeComponent();
            rnd = random.Next(0, tr.Length);                             //make random number from zero to the size of the words array
            string_word = tr[rnd];                                       // create the word
            secret_string_word = new string('-',string_word.Length);     //create the secret word 
           secret_word = secret_string_word.ToCharArray();               // convert the secret word to char array
        }
        private void Form1_Load(object sender, EventArgs e)
        {   label5.Text="1P Score : "+scoreP_1;
            label6.Text="2P Score : "+scoreP_2;
            if (turn == true)
                label7.Text = "1. Player turn";
            else
                label7.Text = "2. Player turn";
            label3.Text = "Health : " + HEALTH.ToString()+"X ❤️‍";       //print the health
            label2.Text = secret_string_word;                            //show the secret word on screen
        }
        private void button1_Click(object sender, EventArgs e)           //when user press Check button this will work
        {
            if (textBox1.Text == "")                                     //control if the input is empty
            {
               MessageBox.Show("Please enter a letter","Not Exist",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else                                                         //if the input is not empty the variable letter will be the letter that we got from input
            {  
                letter =textBox1.Text[0];
            }
            textBox1.Clear();                                            // clear the textbox
            for (int j = 0; j < string_word.Length; j++)                 //for loop to control every index 
            {
                if (letter == string_word[j])                            //if the letter exist will do changes
                {
                    label4.Text="";                                      //remove not exist lable
                    secret_word[j] = letter;                             //put the letter that user enter in the secret word
                    CharArrayToString(secret_word, secret_string_word);                 //function to convert char array to string
                    secret_string_word = new string(secret_word);        //convert the secret word array to string    
                    label2.Text = secret_string_word;                    // cause the label doesnt accept char arrays
                }
            }
            if (!string_word.Contains(letter))                           //if the secret word doesnt find
            {
                    HEALTH--;                                            //the health will get damage
                    switch(HEALTH)                                       //when the health get down the background will change to different photos
                    {
                        case 6:
                            this.BackgroundImage= Image.FromFile("frames\\hangman0.png");
                            break;
                        case 5:
                            this.BackgroundImage= Image.FromFile("frames\\hangman1.png");
                            break;
                        case 4:
                            this.BackgroundImage= Image.FromFile("frames\\hangman2.png");
                            break;
                        case 3:
                            this.BackgroundImage= Image.FromFile("frames\\hangman3.png");
                            break;
                        case 2:       
                            this.BackgroundImage= Image.FromFile("frames\\hangman4.png");
                            break;
                        case 1:
                            this.BackgroundImage= Image.FromFile("frames\\hangman5.png");
                            break;
                        case 0:
                            this.BackgroundImage= Image.FromFile("frames\\hangman6.png");
                            break;
                    }
                    label3.Text = "Health : " + HEALTH.ToString()+"X \u2764\ufe0f"; //update the Health on screen
                    
                    label4.Text="not exist";                             //print this cause the letter not exist

                    if (HEALTH == 0)                                     //when the Health over
                    {
                        MessageBox.Show("You lose , the word was : " +
                         string_word.ToUpper()+"\nthe other player turn!" ,"LOSER",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); //messagebox to show what the word was
                        rnd = random.Next(0, tr.Length);                 //update the random number
                        label4.Text = "";                                //remove the not exist word
                        string_word = tr[rnd];                           //set new word
                        secret_string_word =
                            new string('-', string_word.Length);       //make the secret word from the word length
                        secret_word = secret_string_word.ToCharArray();  //convert the word to char array
                        label2.Text = secret_string_word;                //show the secret word on the screen
                        this.BackgroundImage = Image.FromFile("frames\\hangman_1.png");  //set the default background
                        HEALTH = 7;                                      //set new Health
                        label3.Text =
                            "Health : " + HEALTH.ToString() + "X \u2764\ufe0f"; //show the new Health on screen
                        if (turn == false)                                //if the turn was in 2p
                        { 
                            turn = true;                                  //the turn will be in 1p
                            label7.Text = "1. Player turn";               //show on the screen
                        }
                        else{                                            //if the turn was in 1p
                            turn = false;                                //the turn will be in 2p
                            label7.Text = "2. Player turn";              //show on the screen 
                        } 
                    }
            }
            if (!secret_word.Contains('-'))                              //if the word get finished
            {
                MessageBox.Show("GREAT JOB , you find it  \ud83d\udc4f"+"\n+1 Point","WINNER",MessageBoxButtons.OK,MessageBoxIcon.Information); //congratilation in messagebox
                rnd = random.Next(0, tr.Length);
                label4.Text="";
                string_word = tr[rnd];
                secret_string_word = new string('-',string_word.Length);
                secret_word = secret_string_word.ToCharArray();
                label2.Text = secret_string_word;
                label1.Text = "ADAM ASMA";
                if (turn == true)
                {
                    scoreP_1++;
                    label5.Text = "1P Score : " + scoreP_1.ToString();
                }
                else
                {
                    scoreP_2++;
                    label6.Text = "2P Score : " + scoreP_2.ToString();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e) {label1.Text = "ASMA ADAM"; }
        private void label3_Click(object sender, EventArgs e)            //here will show the secret word when Health get pressed
        {label1.Text = string_word; }                                    //to disapper it press on the secret word
        public static string CharArrayToString(char[] letter, string str) //function that convert the char array to string
        { StringBuilder sb = new StringBuilder(str);
            for (int j = 0; j < letter.Length; j++)
            { sb.Append(letter[j]); }
            return sb.ToString(); }

        private void button2_Click(object sender, EventArgs e){ }
        private void label4_Click(object sender, EventArgs e){ }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e)            // secret trick to set new word and recharg the Health
        { rnd = random.Next(0, tr.Length);
            label4.Text = "";
            string_word = tr[rnd];
            secret_string_word = new string('-', string_word.Length);
            secret_word = secret_string_word.ToCharArray();
            label2.Text = secret_string_word;
            this.BackgroundImage = Image.FromFile("frames\\hangman_1.png");
            HEALTH = 7;
            label3.Text = "Health : " + HEALTH.ToString()+"X \u2764\ufe0f";
            label1.Text = "ADAM ASMA";
        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }
    }
}
