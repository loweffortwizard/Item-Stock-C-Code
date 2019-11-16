/*
	Initialize global variables
*/
        private decimal total;
        //global variable that can be accessed by the whole of Form1 (Homepage) 
        //decimal = numarical software structure for decimals
        int result;
        //global variable that can be accessed by the whole of Form1 (Homepage) 
        //the var result is going to be a numerical value

/*
	InitializeComponent = create form
*/
        public OrderForm()
        {//start of public (OrderForm)

            InitializeComponent();
            //creates form and displays
			
			toolTip1.SetToolTip(BtnAdd, "The add button will add the selected item into the order list.");
            toolTip2.SetToolTip(BtnRemove, "The remove button will remove the selected item form the order list.");
            toolTip3.SetToolTip(BtnClear, "The clear button will remove all items in the order list.");
            toolTip4.SetToolTip(BtnSave, "The save button will save the current order list into a text file in the T drive. Remember to press the new order button after you have saved.");
            toolTip5.SetToolTip(BtnOpen, "The open button will let up open up an existing/allready saved order");
            toolTip6.SetToolTip(BtnNewOR, " The new order button will create a new OR number. You need to do this each time you save an order of you will keep overriding the same file.");
            toolTip7.SetToolTip(BtnPrint, "The print button will open a new form of the current order list for you to print out.");
            toolTip8.SetToolTip(BtnPrintSaved, "The print saved will let up print an existing/allready saved order.");
            toolTip9.SetToolTip(BtnExit, "The Close app button closes the whole appliction.");
            toolTip10.SetToolTip(BtnHowTo, "The How to use button takes you to the help page. ");
            toolTip11.SetToolTip(BtnVeg, "The veg button will open up the current veg stock.");
            toolTip12.SetToolTip(BtnFruit,"The fruit button will open up the current fruit stock.");
            toolTip13.SetToolTip(BtnChangeVeg,"The change veg button will open up a new form.");
            toolTip14.SetToolTip(BtnChangeFruit, "The change fruit button will open up a new form.");
			//above used for tool tips, appear when element hovered over. 

        }//end of public (OrderForm)

/*
	adds item from veg text file to stock list. 
*/
        private void BtnVeg_Click(object sender, EventArgs e)
        {//start of BtnVeg

            LstStock.Items.Clear();
            //Clears current stock

            string[] lines = System.IO.File.ReadAllLines(@"\\filedestination\fruitstock.txt");
            //locates the txt file with the items

            foreach (string line in lines)
            //for every line/item in the document
            {
                LstStock.Items.Add(line);
                //add to the stock
            }

        }//end of BtnVeg

/*
	adds item from fruit text file to stock list. 
*/
		private void BtnFruit_Click(object sender, EventArgs e)
        {//start of BtnFriut

            LstStock.Items.Clear();
            //Clears current stock

            string[] lines = System.IO.File.ReadAllLines(@"\filedestination\fruitstock.txt");
            //locates the txt file with the items

            foreach (string line in lines)
            //for every line/item in the document

            {//start of Foreach
                LstStock.Items.Add(line);
                //add to the stock

            }//end of foreach

        }//end of BtnFriut

/*
	add items to bag
*/

private void BtnAdd_Click(object sender, EventArgs e)
        {//start of BtnAdd

            int selection = LstOrder.SelectedIndex;
            //var selection had the value of the selected item 

            if ((LstStock.SelectedItem != null) && (NumQuantiy.Value > 0))
            //if there is no item selected from LstStock

            {//start of if

                LstOrder.Items.Add(LstStock.SelectedItem);
                //adds selected item in LstStock to LstOrder

                LstQuantCount.Items.Add(NumQuantiy.Value);
                //adds content in NumQuantiy to the LstQuantCount

                //LstStock.Items.Add(NumQuantiy.Value + " x " + LstStock.SelectedItem);

                LstOrder.SelectedIndex = LstOrder.Items.Count - 1;
                //removes LstOrder selected item

                string theItem = LstOrder.SelectedItem.ToString();
                //var theItem has the value of LstOrder selected item

                switch (theItem)
                //DEPENDING ON ITEM WILL GIVE DIFFERENT TOTAL

                {//start of switch

                    case "Red Apple":
                        //item
                        total += 1.00M * NumQuantiy.Value;
                        //total being times by the value in NumQuantiy
                        break;
                    //next item if not this item
                    case "Green Apple":
                        total += 1.00M * NumQuantiy.Value;
                        break;
                    case "Pear":
                        total += 1.00M * NumQuantiy.Value;
                        break;
                    case "Orange":
                        total += 1.0M * NumQuantiy.Value;
                        break;

                }//end of switch

                LblTotal.Text = ("Total: £" + Convert.ToString(total));
                //prints out the total, on LblTotal

                selection = LstOrder.SelectedIndex;
                //var selection has the value of the selected item

                LstQuantCount.SelectedIndex = selection;
                //LstQuantCount has the value var selection

                result = 0;
                //var result has the value of 0

                for (int itemcount = 0; itemcount < LstQuantCount.Items.Count; itemcount++)
                //var itemcount has the value of 0
                //as long as itemcount has a value smaller then LstQuantCount
                //var LstQuantCount will add 1

                {//start of for

                    result += Convert.ToInt16(LstQuantCount.Items[itemcount]);
                    //result now has the value of the item in LstQuantCount

                }//end of for 

                LblAmountItem.Text = "Item count: " + Convert.ToString(result);
                //prints out the total number of items, on LblAmountItem

            }//end of if
        
            else
            {//start of else

                MessageBox.Show("Please select an item and a quantity.");
                //displaying the messagebox.

            }//end of else

            //LblTotal.Text = ("Total: £" + Convert.ToString(total));
            //prints out the total, on LblTotal

        }//end of BtnAdd

/*
	to remove item from bag
*/

private void BtnRemove_Click(object sender, EventArgs e)
        {//start of remove 

            int selection;
            //var selection has numerical value

            selection = LstOrder.SelectedIndex;
            //var selection has the value of the selected item in LstOrder 

            LstQuantCount.SelectedIndex = selection;
            //LstQuantCount has the value var selection

            if (Convert.ToInt16(LstQuantCount.SelectedItem) >= NumQuantiy.Value)
            //if LstQuantCount selected item is = or > NumQuantiy

            {//start of if

                string theitem = LstOrder.SelectedItem.ToString();
                //new var has the value of the SelectedItem

                switch (theitem)
                {//start of switch

                    case "Red Apple":
                        //item
                        total = total - (1.00M * NumQuantiy.Value);
                        //takes away from total
                        break;
                    //next item if not this item
                    case "Green Apple":
                        total = total - (1.00M * NumQuantiy.Value);
                        break;
                    case "Pear":
                        total = total - (1.00M * NumQuantiy.Value);
                        break;
                    case "Orange":
                        total = total - (1.00M * NumQuantiy.Value);
						break;

                }//end of switch

                LblTotal.Text = ("Total Price: £" + Convert.ToString(total));
                //prints out the total, on LblTotal

                selection = LstOrder.SelectedIndex;
                //var selection has the value of the selected item in LstOrder 

                LstQuantCount.SelectedIndex = selection;
                //LstQuantCount has the value var selection

            }//end of if

            if (Convert.ToInt16(LstQuantCount.SelectedItem) > NumQuantiy.Value)
            //if LstQuantCount selected item has a greater value then the value in NumQuantiy

            {//start of if

                LstQuantCount.Items[selection]=Convert.ToString(Convert.ToInt16(LstQuantCount.SelectedItem)-NumQuantiy.Value);
                //converts from int to string the selected item from LstQuantCount. Then takes away the value of NumQuantiy from LstQuantCount

            }//end of if

            else if (Convert.ToInt16(LstQuantCount.SelectedItem) == NumQuantiy.Value)
            // else if LstQuantCount selected item has the same value then the value in NumQuantiy

            {//start of else if

                LstOrder.Items.Remove(LstOrder.SelectedItem);
                //removes selected item from LstOrder

                LstQuantCount.Items.RemoveAt(selection);
                //removes selected quantiy from LstQuantCount

            }//start of else if

            else 
            //if none of the about requierments are meet

            {//start of else 

                MessageBox.Show("You do not have that many items to remove from the order", "Please have an item selected to remove");
                //Displays a messagebox

            }//end of else 

            result = 0;
            //var result has the value of 0

                for (int itemcount = 0; itemcount < LstQuantCount.Items.Count; itemcount++)
                //var itemcount has the value of 0
                //as long as itemcount has a value smaller then LstQuantCount
                //var LstQuantCount will add 1

                {//start of for

                    result += Convert.ToInt16(LstQuantCount.Items[itemcount]);
                    //result now has the value of the item in LstQuantCount

                }//end of for 

                LblAmountItem.Text = "Item count: " + Convert.ToString(result);
                //prints out the total number of items, on LblAmountItem 
  
        }//end of remove

/*
	below used for unique id for order
*/		
		private void OrderForm_Load(object sender, EventArgs e)
        {//start of OrderForm

            LblTotal.Text = ("Total: £" + Convert.ToString(total));

            LblTime.Text = DateTime.Now.ToLongTimeString();
            //displays current Date in LblDate

            LblDate.Text = DateTime.Now.ToLongDateString();
            //displays current Date in LblDate

            String NumberGen = Convert.ToString(DateTime.Now);
            //var NumberGen = the current data and time

            NumberGen = NumberGen.Replace("/", "");
            //this is getting rid of the / in the date
            NumberGen = NumberGen.Replace(":", "");
            //this is getting rid of the : in the time
            NumberGen = NumberGen.Replace(" ", "");
            //this is getting rid of the " " in the time and date

            LblNumberGen.Text = NumberGen;
            //making the lable have the value of the NumberGen variable

            BtnPrintSaved.Hide();
            //hides the print button

        }//end of OrderForm
		
/*
	used to open a text file. 
*/
private void BtnOpen_Click(object sender, EventArgs e)
        {//start of open

            OpenFileDialog OrderFile = new OpenFileDialog();
            //this is using pre-built program to s create a new open file and call it f (f = variable)

            MessageBox.Show("Please select a text file from the T drive");
            //displays message box

            if (OrderFile.ShowDialog() == DialogResult.OK)
            {//start of if

                LstOrder.Items.Clear();
                //this retrives the items and then clears the text in the order form
                string[] lines = System.IO.File.ReadAllLines(OrderFile.FileName);
                //creating a variable (lines) to represent a system file that will read all text and store that in a new variable (FileName)

                foreach (string line in lines)
                {//start of foreach

                    LstOrder.Items.Add(line);
                    //adds items in LstOrder 

                }//end of foreach

                string theFileName = OrderFile.FileName;
                theFileName = theFileName.Remove(theFileName.Length - 4);
                //this will take away the last 4 digits in the variable file name

                theFileName = theFileName.Remove(0, 3);
                //this will take away the first 3 didgits in the variable file name

                LstStock.Text = theFileName;
                //LstStock has the values of the var theFileName

            } // end of if

        }//end of open