using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragons2
{
    public partial class Form1 : Form
    {
        List<String> cards = new List<string>(66);
        List<int> position = new List<int>(5) { 1, 2, 3, 4, 5 };
        LinkedList<String> dragonsColors = new LinkedList<string>();
        readonly string blancCard = @"C:\Users\Slayer1\Desktop\Cards\Blanc.bmp";
        readonly string silverDragon = @"C:\Users\Slayer1\Desktop\Cards\SilverDragon.png";
        readonly string stringDeckCards = @"C:\Users\Slayer1\Desktop\Cards\All\";
        readonly string startingDragon = @"C:\Users\Slayer1\Desktop\Cards\Starting cards\";
        readonly string ForegroundCard = @"C:\Users\Slayer1\Desktop\Cards\Foreground Card.png";
              

        string selectedCardName = null;
        readonly string silverDragonString = "silverDragon";
        readonly string BlancCardString = "BlancCard";
        readonly string colorfulDragonString = "1jjjj";
        readonly string actionCardString = "a";
        public string rotationBlueAction = null;

        int playerCardsRow = 0;
        int playerCardsColumn = 0;
        int oldPaddingRow = 99;
        int oldPaddingColumn = 99;
        int rowRedActCard = 99;
        int columnRedActCard = 99;
        int rowMiddle = 0;
        int columnMiddle = 0;
        int cardsOnPlayField = 0;
        int cardsToTakeFromDeck = 0;

        private int numberOfPlayers;
       
        public int NumberOfPlayers // This is your property
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }
        }

        int numberOfTurns = 0;

        bool WithoutAction = false;
        bool successPlacingCardOnPlayGround = false;        

        Image selectedCardImage = null;

        readonly Padding noPadding = new Padding(0, 0, 0, 0);
        readonly Padding newPadding = new Padding(5, 5, 5, 5);

        Players[] players;

        public Form1()
        {         
            InitializeComponent();

            PlayersCount playersCount = new PlayersCount(this);
            playersCount.ShowDialog();

            players = new Players[numberOfPlayers];
            getPlayers(players, numberOfPlayers);
            
        }       

        private void getPlayers(Players[] players, int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
                players[i] = new Players(i, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disablePictureBoxesClicking();      // clicking on pictureboxes will be used during yellow dragon action

            preparePlayField();

            putSilverDragon();

            setStartingDragon();           

            pb1.Image = Image.FromFile(ForegroundCard);
            pb2.Image = Image.FromFile(ForegroundCard);
            pb3.Image = Image.FromFile(ForegroundCard);
            pb4.Image = Image.FromFile(ForegroundCard);
            pb5.Image = Image.FromFile(ForegroundCard);

            ShowNextPlayerDragonCard(0);

            createPlayerCards();

            string[] cardsToDeck = DeckCards.getDeckCards(stringDeckCards);
            cards = DeckCards.fillDeck(cardsToDeck);
            cards.Shuffle();    // Shuffle the cards  https://stackoverflow.com/questions/273313/randomize-a-listt

            Get3StartingCards();    // get first 3 starting cards 

            label1.Text = (numberOfTurns + 1).ToString();
            label2.Text = (numberOfTurns + 1).ToString();
            label7.Text = players[numberOfTurns % numberOfPlayers].getMessage();

            FirstPhase();
        }

        private void setStartingDragon()
        {
            string[] startingDragons = DeckCards.getDeckCards(startingDragon);
            List<string> dragonsColorsList = DeckCards.fillPlayersColors(startingDragons);
            dragonsColorsList.Shuffle();
            position.Shuffle();

            AddDragonColorsToPlayers(players, numberOfPlayers, dragonsColorsList, position);

            dragonsColors = PlayersColors.listToLinkedList(dragonsColorsList);
        }

        private void AddDragonColorsToPlayers(Players[] players, int numberOfPlayers, List<string> dragonsColorsList, List<int> position)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                players[i].Position = position[i];
                players[i].PlayerDragonColor = dragonsColorsList[position[i] - 1];
            }
        }        

        private void preparePlayField()
        {
            dgvPlayField.RowTemplate.Height = 140;     // https://stackoverflow.com/questions/3370236/changing-the-row-height-of-a-datagridview         

            Image image = Image.FromFile(blancCard);
            DataGridViewImageColumn[] iconColumn = new DataGridViewImageColumn[13];
           
            for (int i = 0; i < iconColumn.Length; i++)
            {
                iconColumn[i] = new DataGridViewImageColumn();
                iconColumn[i].Image = image;
                iconColumn[i].Name = "Dragon" + i;
                iconColumn[i].HeaderText = "";
                iconColumn[i].ImageLayout = DataGridViewImageCellLayout.Stretch;    // will do the trick https://stackoverflow.com/questions/46168609/fit-image-into-datagridview-column?rq=1

                dgvPlayField.Columns.Add(iconColumn[i]);
                dgvPlayField.Rows[dgvPlayField.NewRowIndex].Cells["Dragon" + i].Tag = BlancCardString;
                dgvPlayField.Rows[dgvPlayField.NewRowIndex].Cells["Dragon" + i].Value = image;  // https://stackoverflow.com/questions/30802160/image-displaying-a-red-x-in-a-datagridview-when-loading-from-resources

                if (i < 6)
                    dgvPlayField.Rows.Add();
            }

            for (int i = 0; i < dgvPlayField.RowCount; i++)       // set tag property to all blanc card
            {
                for (int j = 0; j < dgvPlayField.ColumnCount; j++)
                {
                    dgvPlayField.Rows[i].Cells[j].Tag = BlancCardString;
                }
            }
        }

        private void putSilverDragon()
        {
            Bitmap bmp = (Bitmap)Bitmap.FromFile(silverDragon);

            DataGridViewImageCell iCell = new DataGridViewImageCell();
            iCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            iCell.Value = bmp;
            iCell.Tag = silverDragonString;

            rowMiddle = dgvPlayField.RowCount / 2;
            columnMiddle = dgvPlayField.ColumnCount / 2;
           
            dgvPlayField[columnMiddle, rowMiddle] = iCell;
        }


        private void Get3StartingCardsForAllPlayers(Players[] players, int numberOfPlayers)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < numberOfPlayers; j++)
                {
                    string cardname = GlobalMethods.getCardFromDeck(cards);
                    removeCard();   // remove this card from List because is in hand of player

                    players[j].playersCards.Add(cardname);
                }
            }
        }


        private void Get3StartingCards()
        {
            Get3StartingCardsForAllPlayers(players, numberOfPlayers);

            for (int i = 0; i < 3; i++)
            {
                int row = playerCardsRow;
                int column = playerCardsColumn;

                DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[row].Cells[column];

                string cardname = players[0].playersCards[i];             

               
                string fileName = stringDeckCards + cardname + ".png";
                Image imageInput = Image.FromFile(fileName);

                cellPlayerCardsInput.ImageLayout = DataGridViewImageCellLayout.Stretch;
                cellPlayerCardsInput.Value = imageInput;
                cellPlayerCardsInput.Tag = cardname; // name of card, https://stackoverflow.com/questions/33689250/how-do-i-get-the-bitmap-name-when-i-click-the-image-in-datagridview 


                playerCardsRow = GridControl.recomputeRow(row, column);
                playerCardsColumn = GridControl.recomputeColumn(column);
            }
        }       

        private void createPlayerCards()  // create empty place 3x3 for player cards 
        {
            dgvPlayerCards.RowTemplate.Height = 140;
           
            Image image = Image.FromFile(blancCard);
            DataGridViewImageColumn[] iconColumn = new DataGridViewImageColumn[3];

            for (int i = 0; i < iconColumn.Length; i++)
            {
                iconColumn[i] = new DataGridViewImageColumn();
                iconColumn[i].Image = image;
                iconColumn[i].Name = "Dragon" + i;
                iconColumn[i].HeaderText = "";
                iconColumn[i].ImageLayout = DataGridViewImageCellLayout.Stretch;    // will do the trick https://stackoverflow.com/questions/46168609/fit-image-into-datagridview-column?rq=1

                dgvPlayerCards.Columns.Add(iconColumn[i]);
                dgvPlayerCards.Rows[dgvPlayerCards.NewRowIndex].Cells["Dragon" + i].Tag = BlancCardString;
                dgvPlayerCards.Rows[dgvPlayerCards.NewRowIndex].Cells["Dragon" + i].Value = image;  // https://stackoverflow.com/questions/30802160/image-displaying-a-red-x-in-a-datagridview-when-loading-from-resources

                if (i < 2)
                    addRowPlayerCards();
            }

            for (int i = 0; i < dgvPlayerCards.RowCount; i++)       // set tag property to all blanc card
            {
                for (int j = 0; j < dgvPlayerCards.ColumnCount; j++)
                {
                    dgvPlayerCards.Rows[i].Cells[j].Tag = BlancCardString;
                }
            }
        }

        private void dgvPlayField_CellClick(object sender, DataGridViewCellEventArgs e)
        {    
            if (RedDragonAction.takeFromPlayField_FirstPhaseRedAction)          // take card from playlield when there is red dragon action
            {
                RedDragonAction.placeToPlayerSet_SecondPhase = false;   // ban place card to player set from playfield during red action                 

                if (rowRedActCard != 99 && columnRedActCard != 99)
                {
                    if (!((e.RowIndex == rowRedActCard) && (e.ColumnIndex == columnRedActCard)))
                        DeselectCardRedDragonAction(rowRedActCard, columnRedActCard, false);
                }

                if (isPaddingPlayField(e.RowIndex, e.ColumnIndex))
                {
                    DeselectCardRedDragonAction(e.RowIndex, e.ColumnIndex, true);
                }
                else
                {
                    SelectCardRedDragonAction(e.RowIndex, e.ColumnIndex);

                    rowRedActCard = e.RowIndex;
                    columnRedActCard = e.ColumnIndex;

                    RedDragonAction.placeToPlayerSet_SecondPhase = true;        // allow place card to player set from playfield during red action                       
                }
            }
            else
            {
                if (!BlueDragonAction.BlueDragonActionFlag && !GoldDragonAction.GoldDragonActionFlag)
                    putCardOnPlayField(e.RowIndex, e.ColumnIndex);
            } 

            if (GreenDragonAction.takeFromPlayField_FirstPhaseGreenAction)          // take card from playlield when there is green dragon action
            {  
                if (rowRedActCard != 99 && columnRedActCard != 99)
                {
                    if (!((e.RowIndex == rowRedActCard) && (e.ColumnIndex == columnRedActCard)))
                        DeselectCardRedDragonAction(rowRedActCard, columnRedActCard, false);
                }

                if (isPaddingPlayField(e.RowIndex, e.ColumnIndex))
                {
                    DeselectCardRedDragonAction(e.RowIndex, e.ColumnIndex, true);
                }
                else
                {
                    SelectCardRedDragonAction(e.RowIndex, e.ColumnIndex);

                    rowRedActCard = e.RowIndex;
                    columnRedActCard = e.ColumnIndex;

                             
                    GreenDragonAction.placeToPlayField_SecondPhaseGreenAction = true;      // allow relocate card from playfield to another place in playfield during green action
                }
            }           

            WithoutAction = false;


            if (!((RedDragonAction.takeFromPlayField_FirstPhaseRedAction) || (RedDragonAction.placeToPlayerSet_SecondPhase) || (RedDragonAction.ThirdPhase) ||
                (GreenDragonAction.takeFromPlayField_FirstPhaseGreenAction) || (GreenDragonAction.placeToPlayField_SecondPhaseGreenAction)))
            {
                if (successPlacingCardOnPlayGround)
                {
                    if(cardsToTakeFromDeck > 0)
                        pbCardDeck.Enabled = true;

                    
                    if (cardsToTakeFromDeck == 0)
                        SetupForNextPlayer();
                }
            }            
        }

        private void SetupForNextPlayer()
        {
            int playerIndex = numberOfTurns % numberOfPlayers;
            HidePreviousPlayerDragonCard(playerIndex);
                
            numberOfTurns += 1;
            UpgradeCounterLabel(numberOfTurns);

            if(!BlackDragonAction.SecondPhaseBlackDragonActionDontSaveCards)     // if tehre were black dragon action(card changing) dont save cards from players hand to current player, because cards are set properly after action
            {
                SavePlayersCards();                
            }
            BlackDragonAction.SecondPhaseBlackDragonActionDontSaveCards = false;

            BlancPlayersCardsOnPlayerGrid();
            ResetRowAndColumn();

            playerIndex = numberOfTurns % numberOfPlayers;

            PutCardsOfAnotherPlayerIntoPlayCardsGrid(playerIndex);
            
            ShowNextPlayerDragonCard(playerIndex);
           
            FirstPhase();

            successPlacingCardOnPlayGround = false;
        }

        private void HidePreviousPlayerDragonCard(int playerIndex)
        {
            switch(players[playerIndex].Position)
            {
                case 1:
                    pb1.Image = Image.FromFile(ForegroundCard);
                    break;
                case 2:
                    pb2.Image = Image.FromFile(ForegroundCard);
                    break;
                case 3:
                    pb3.Image = Image.FromFile(ForegroundCard);
                    break;
                case 4:
                    pb4.Image = Image.FromFile(ForegroundCard);
                    break;
                case 5:
                    pb5.Image = Image.FromFile(ForegroundCard);
                    break;
            }            
        }

        private void ShowNextPlayerDragonCard(int playerIndex)
        {          
            switch(players[playerIndex].Position)
            {
                case 1:
                    pb1.Image = Image.FromFile(startingDragon + players[playerIndex].PlayerDragonColor + ".png");
                    break;
                case 2:
                    pb2.Image = Image.FromFile(startingDragon + players[playerIndex].PlayerDragonColor + ".png");
                    break;
                case 3:
                    pb3.Image = Image.FromFile(startingDragon + players[playerIndex].PlayerDragonColor + ".png");
                    break;
                case 4:
                    pb4.Image = Image.FromFile(startingDragon + players[playerIndex].PlayerDragonColor + ".png");
                    break;
                case 5:
                    pb5.Image = Image.FromFile(startingDragon + players[playerIndex].PlayerDragonColor + ".png");
                    break;
            }
        }

        /// <summary>
        /// Player in first phase cannot move cards from hand but first must take it from the deck
        /// </summary>
        private void FirstPhase()
        {
            pbCardDeck.Enabled = true;
            dgvPlayerCards.Enabled = false;
        }

        private void SavePlayersCards()
        {
            int player = ((numberOfTurns-1) % numberOfPlayers);
            players[player].playersCards.Clear();

            for(int i = 0; i < dgvPlayerCards.RowCount; i++)
            {
                for(int j = 0; j < dgvPlayerCards.ColumnCount; j++)
                {
                    DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[i].Cells[j];

                    if((string)cellPlayerCardsInput.Tag == BlancCardString)
                        return;
                    else
                    {
                        players[player].playersCards.Add(cellPlayerCardsInput.Tag.ToString());
                    }

                }
            }
        }

        /// <summary>
        /// Set row and column to 0 in order to compute where to place cards of other player properly
        /// </summary>
        private void ResetRowAndColumn()
        {
            playerCardsRow = 0;
            playerCardsColumn = 0;
        }

        private void PutCardsOfAnotherPlayerIntoPlayCardsGrid(int playerIndex)
        {
            int playersCardsCount = players[playerIndex].playersCards.Count;
            for(int i = 0; i < playersCardsCount; i++)
            {
                int row = playerCardsRow;
                int column = playerCardsColumn;
                
                DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[row].Cells[column];

                string cardname = players[playerIndex].playersCards[i];
               
                string fileName = stringDeckCards + cardname + ".png";
                Image imageInput = Image.FromFile(fileName);

                cellPlayerCardsInput.ImageLayout = DataGridViewImageCellLayout.Stretch;
                cellPlayerCardsInput.Value = imageInput;
                cellPlayerCardsInput.Tag = cardname; // name of card, https://stackoverflow.com/questions/33689250/how-do-i-get-the-bitmap-name-when-i-click-the-image-in-datagridview 


                playerCardsRow = GridControl.recomputeRow(row, column);
                playerCardsColumn = GridControl.recomputeColumn(column);
            }
        }

        private void UpgradeCounterLabel(int numberOfTurns)
        {
            label1.Text = (numberOfTurns + 1).ToString();

            label2.Text = ((numberOfTurns % numberOfPlayers) + 1).ToString();

            label7.Text = players[numberOfTurns % numberOfPlayers].getMessage();            
        }

        private void SelectCardRedDragonAction(int rowIndex, int columnIndex)
        {
            DataGridViewImageCell cellPlayFieldInput = (DataGridViewImageCell)dgvPlayField.Rows[rowIndex].Cells[columnIndex];

            if (cellPlayFieldInput.Tag.ToString() != BlancCardString)                      // if there is any card
            {
                if (!(cellPlayFieldInput.RowIndex == rowMiddle && cellPlayFieldInput.ColumnIndex == columnMiddle))    // cannot take card on the place where is/was silver dragon card
                {
                    cellPlayFieldInput.Style = new DataGridViewCellStyle { Padding = newPadding };     // highlights edges

                    rowRedActCard = rowIndex;
                    columnRedActCard = columnIndex;

                    selectedCardImage = (Image)cellPlayFieldInput.Value;
                    selectedCardName = cellPlayFieldInput.Tag.ToString();
                }
            }
        }

        private void DeselectCardRedDragonAction(int oldPaddingRowLocal, int oldPaddingColumnLocal, bool setOldCards)
        {
            dgvPlayField.Rows[oldPaddingRowLocal].Cells[oldPaddingColumnLocal].Style = new DataGridViewCellStyle { Padding = noPadding };  // set no pading for previous selected card                      

            if (selectedCardName != null)
                if (selectedCardName.Substring(0, 1) != actionCardString)
                {
                    if (!GreenDragonAction.placeToPlayField_SecondPhaseGreenAction)
                        setCardToNull();
                }

            if (setOldCards)
            {
                rowRedActCard = 99;
                columnRedActCard = 99;
            }
        }

        private void putCardOnPlayField(int RowIndex, int ColumnIndex)
        {
            DataGridViewImageCell cellInput = (DataGridViewImageCell)dgvPlayField.Rows[RowIndex].Cells[ColumnIndex];
            if (selectedCardName != null && selectedCardImage != null)                              // if there is any card chosen
            {
                if (selectedCardName.Substring(0, 1) != actionCardString)                        // I put action card
                {
                    if (!isSilverDragonPlace(RowIndex, ColumnIndex)/*(string)cellInput.Tag != silverDragonString*/ && !GlobalMethods.existAnotherCard(cellInput))    // if card is not putting on Silver dragon place and card is not putting on card that was already put?
                    {
                        if (hasNeighboringCard(cellInput))      // is there any adjacent card?
                        {
                            if (isSameColor(cellInput) || selectedCardName == colorfulDragonString)
                            {
                                putCardOnPlayField(cellInput);

                                successPlacingCardOnPlayGround = true;
                            }
                        }
                    }
                }
                else if (selectedCardName.Substring(0, 1) == actionCardString && isSilverDragonPlace(RowIndex, ColumnIndex))    // if I want to put action card and I am putting it on the place where is/was Silver dragon card
                {
                    if ((selectedCardName.Substring(1, 1) == "r" || selectedCardName.Substring(1, 1) == "v") && cardsOnPlayField == 0)      // if there is no cards on playfield and player plays red or green action, card can be only put on silver dragon without preforming action
                    {
                        DialogResult dialogResult = MessageBox.Show("Card will put on the silver dragon card, beacause there is no other action possible cause zero cards are on playfield.", "", MessageBoxButtons.OK);

                        putCardOnPlayField(cellInput);

                        successPlacingCardOnPlayGround = true;

                        WithoutAction = true;

                        setCardToNull();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to put action card on and change the color (yes), or you do not want to change color and so put the car under?", "Where to place action card?", MessageBoxButtons.YesNo);
                        if(dialogResult == DialogResult.Yes)
                        {
                            putCardOnPlayField(cellInput);

                            DialogResult dialogResult2 = MessageBox.Show(" Do you want also perform action of the card?", "Action card decision?", MessageBoxButtons.YesNo);
                            if(dialogResult2 == DialogResult.Yes)
                            {
                                performAction(selectedCardName);
                            }
                            else
                            {
                                successPlacingCardOnPlayGround = true;
                            }

                            setCardToNull();
                        }
                        else if(dialogResult == DialogResult.No)
                        {
                            removeCardFromPlayerSet(0, 0);
                            DeselectCard(oldPaddingRow, oldPaddingColumn, true);

                            performAction(selectedCardName);


                            setCardToNull();
                        }
                    }
                }
            }
        }

        private void performAction(string selectedCardName)
        {
            selectedCardName = selectedCardName.Substring(1, 1);

            switch (selectedCardName)
            {
                case "r":
                    TakeCardAndUse();
                    break;
                case "b":
                    rotateCards();
                    break;
                case "o":
                    ChangeColor();
                    break;
                case "v":
                    RelocateCard();
                    break;
                case "n":
                    CardsChanging();    // you can inspire by chamge color method
                    break;

            }
        }

        private void CardsChanging()
        {
            BlackDragonAction.FirstPhaseBlackDragonAction = true;

            disableClicking(true);

            enablePictureBoxesClicking();
        }

        private void RelocateCard()
        {            
            disableClicking(false);

            GreenDragonAction.takeFromPlayField_FirstPhaseGreenAction = true;


        }

        private void ChangeColor()
        {
            GoldDragonAction.GoldDragonActionFlag = true;

            disableClicking(true);

            enablePictureBoxesClicking();
        }

        private void enablePictureBoxesClicking()
        {
            pb1.Enabled = true;
            pb2.Enabled = true;
            pb3.Enabled = true;
            pb4.Enabled = true;
            pb5.Enabled = true;
        }

        private void disableClicking(bool use)
        {
            if (use)
                dgvPlayField.Enabled = false;

            pbCardDeck.Enabled = false;
            dgvPlayerCards.Enabled = false;
        }

        private void rotateCards()
        {
            BlueDragonAction.BlueDragonActionFlag = true;

            Rotation rotation = new Rotation(this);
            rotation.Show();
        }

        public void rotateCardsDirection(string rotationBlueAction)
        {
            if (rotationBlueAction == "Left")
            {                          
                rotateLeft();   // https://stackoverflow.com/questions/9948202/easiest-way-to-rotate-a-list-in-c-sharp

                BlueDragonAction.BlueDragonActionFlag = false;

            }
            else if (rotationBlueAction == "Right")
            {
                rotateRight();            

                BlueDragonAction.BlueDragonActionFlag = false;
            }            

            SetupForNextPlayer();
        }

        private void rotateRight()
        {
            string last = dragonsColors.Last.Value.ToString();
            dragonsColors.RemoveLast();
            dragonsColors.AddFirst(last);

            dragonsColors = ChangePlayersColorsAfterRotation(dragonsColors);
        }

        private void rotateLeft()
        {
            string first = dragonsColors.First.Value.ToString();
            dragonsColors.RemoveFirst();
            dragonsColors.AddLast(first);

            dragonsColors = ChangePlayersColorsAfterRotation(dragonsColors);
        }

        private LinkedList<string> ChangePlayersColorsAfterRotation(LinkedList<string> dragonsColors)
        {
            List<String> localListRotate = new List<string>();
            localListRotate = PlayersColors.LinkedListToList(dragonsColors);

            ChangePlayersColorsAfterRotation(localListRotate);

            dragonsColors = PlayersColors.listToLinkedList(localListRotate);

            return dragonsColors;
        }

        /// <summary>
        /// Change colors of players dragon colors after rotation of colors in linked list
        /// </summary>
        /// <param name="localListRotate"></param>
        private void ChangePlayersColorsAfterRotation(List<String> localListRotate)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                int positionRotate = players[i].Position;
                players[i].PlayerDragonColor = localListRotate[positionRotate - 1];
            }
        }

        private void TakeCardAndUse()   // red dragon action
        {
            pbCardDeck.Enabled = false;
            DragonAction.PickFromSet = false;     // prevent picking card from players set

            RedDragonAction.takeFromPlayField_FirstPhaseRedAction = true;   // allow taking card from playfield

            selectedCardName = null;
            selectedCardImage = null;
        }

        private bool isSilverDragonPlace(int row, int column)
        {
            if (dgvPlayField.Rows[row].Cells[column] == dgvPlayField[dgvPlayField.ColumnCount / 2, dgvPlayField.RowCount / 2])
                return true;
            else
                return false;
        }

        private void putCardOnPlayField(DataGridViewImageCell cellInput)
        {            
            cellInput.Value = selectedCardImage;
            cellInput.Tag = selectedCardName;       // name of card, https://stackoverflow.com/questions/33689250/how-do-i-get-the-bitmap-name-when-i-click-the-image-in-datagridview 

            if (!GreenDragonAction.placeToPlayField_SecondPhaseGreenAction)    // do not remove card from player set during second phase of green dragon action 
            {
                removeCardFromPlayerSet(0, 0);

                DeselectCard(oldPaddingRow, oldPaddingColumn, true);

                pbCardDeck.Enabled = true;
            }

            if (GreenDragonAction.placeToPlayField_SecondPhaseGreenAction)
            {
                removeOldRelocatedCardFromPlayField();
            }

            if (selectedCardName == null)       // card was regular card and not action card              
                cardsOnPlayField++;
        }

        private void removeOldRelocatedCardFromPlayField()
        {
            setCardToNull();
           
            removeCardFromPlayFieldAfterRedDragonAction();

            GreenDragonAction.takeFromPlayField_FirstPhaseGreenAction = false;
            GreenDragonAction.placeToPlayField_SecondPhaseGreenAction = false;

            RedDragonAction.placeToPlayerSet_SecondPhase = false;

            enableClicking();
        }

        /*
        /// <summary>
        /// Has at least one of adjacent cards the same color as the card that I want to put on the playground?
        /// </summary>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool isSameColor(DataGridViewImageCell cellInput)
        {
            char[] color = new char[4];
            color = GlobalMethods.splitCardColor(selectedCardName);

            if (matchUpperLeftColor(color[0], cellInput) || matchUpperRightColor(color[1], cellInput)  || matchLowerLeftColor(color[2], cellInput) || matchLowerRightColor(color[3], cellInput))
                return true;
            else
                return false;
        }
        */

        /// <summary>
        /// Has at least one of adjacent cards the same color as the card that I want to put on the playground?
        /// </summary>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool isSameColor(DataGridViewImageCell cellInput)
        {
            char[] color = new char[4];
            bool[] colorMatch = new bool[4];

            color = GlobalMethods.splitCardColor(selectedCardName);

            colorMatch = GetColorMatch(color, cellInput);

            getCountOfCardsToTakeFromDeck(color, colorMatch);

            bool isColorMatch = IsColorMatch(colorMatch);

            if(isColorMatch)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get true if there is same color in afjacent cards or false if not
        /// </summary>
        /// <param name="color"></param>
        /// <param name="cellInput"></param>
        /// <returns></returns>
        private bool[] GetColorMatch(char[] color, DataGridViewImageCell cellInput)
        {
            bool[] colorMatchLocal = new bool[4];

            colorMatchLocal[0] = matchUpperLeftColor(color[0], cellInput);
            colorMatchLocal[1] = matchUpperRightColor(color[1], cellInput);
            colorMatchLocal[2] = matchLowerLeftColor(color[2], cellInput);
            colorMatchLocal[3] = matchLowerRightColor(color[3], cellInput);

            return colorMatchLocal;
        }        

        /// <summary>
        /// Get number of cards to take from deck
        /// </summary>
        /// <param name="color"></param>
        /// <param name="colorMatch"></param>
        private void getCountOfCardsToTakeFromDeck(char[] color, bool[] colorMatch)
        {
            HashSet<char> colorSet = new HashSet<char>();
           
            for(int i = 0; i < color.Length; i++)
            {
                if(colorMatch[i])
                {
                    colorSet.Add(color[i]);     // HashSet add only unique values
                       
                }
            }

            SetCountOfCardsToTakeFromDeck(colorSet);
            
        }

        /// <summary>
        /// Set the number of cards that current player can additionally take from deck
        /// </summary>
        /// <param name="colorSet"></param>
        private void SetCountOfCardsToTakeFromDeck(HashSet<char> colorSet)
        {
            if(cardsToTakeFromDeck > 1)                     // if there is more color matches than 1
            {
                if((colorSet.Count == cardsToTakeFromDeck) || (colorSet.Count < cardsToTakeFromDeck)) // and if color matches are equal to number of unique colors
                {
                    cardsToTakeFromDeck = colorSet.Count;
                    cardsToTakeFromDeck -= 1;

                    dgvPlayerCards.Enabled = false;
                }
            }
            else
                cardsToTakeFromDeck = 0;
        }

        /// <summary>
        /// Is there the same color in any of adjacent cards?
        /// </summary>
        /// <param name="colorMatch"></param>
        /// <returns></returns>
        private bool IsColorMatch(bool[] colorMatch)
        {
            for(int i = 0; i < colorMatch.Length; i++)
            {
                if(colorMatch[i])
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check whether upper left color of card that I want to put on playfield matches with at least one of two neighboring cards (lower left or upper right colors)
        /// </summary>
        /// <param name="upperLeftColor">Upper left color of card that I want to put on playfield</param>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool matchUpperLeftColor(char upperLeftColor, DataGridViewImageCell cellInput)
        {
            // check whether upper and left cell are blanc or contain card.
            string NeighborUp = (cellInput.RowIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex - 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;            
            string NeighborLeft = (cellInput.ColumnIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex - 1].Tag.ToString() : BlancCardString;

            if (NeighborUp == silverDragonString || NeighborLeft == silverDragonString ||   // if one these 2 cards is Silver dragon card or Colorful (joker) dragon                
                NeighborUp == colorfulDragonString || NeighborLeft == colorfulDragonString)
                return true;
          
            if (NeighborUp != BlancCardString)                                  // are the colors same?
            {
                char upNeighborLowerLeftColor = GlobalMethods.getParticularSplitCardColor(NeighborUp, 2);

                if(GlobalMethods.checkColorMatch(upperLeftColor, upNeighborLowerLeftColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }            

            if (NeighborLeft != BlancCardString)                                  // are the colors same?
            {
                char leftNeighborUpperRightColor = GlobalMethods.getParticularSplitCardColor(NeighborLeft, 1);

                if (GlobalMethods.checkColorMatch(upperLeftColor, leftNeighborUpperRightColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }           

            return false;
        }

        /// <summary>
        /// Check whether upper right color of card that I want to put on playfield matches with at least one of two neighboring cards (lower right or upper left colors)
        /// </summary>
        /// <param name="upperLeftColor">Upper left color of card that I want to put on playfield</param>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool matchUpperRightColor(char upperRightColor, DataGridViewImageCell cellInput)
        {
            // check whether upper and left cell are blanc or contain card.
            string NeighborUp = (cellInput.RowIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex - 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;
            string NeighborRight = (cellInput.ColumnIndex + 1 < dgvPlayField.ColumnCount) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex + 1].Tag.ToString() : BlancCardString;

            if (NeighborUp == silverDragonString || NeighborRight == silverDragonString ||   // if one these 2 cards is Silver dragon card or Colorful (joker) dragon
                NeighborUp == colorfulDragonString || NeighborRight == colorfulDragonString)
                return true;

            if (NeighborUp != BlancCardString)                                  // are the colors same?
            {
                char upNeighborLowerRightColor = GlobalMethods.getParticularSplitCardColor(NeighborUp, 3);

                if (GlobalMethods.checkColorMatch(upperRightColor, upNeighborLowerRightColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            if (NeighborRight != BlancCardString)                                  // are the colors same?
            {
                char rightNeighborUpperLeftColor = GlobalMethods.getParticularSplitCardColor(NeighborRight, 0);

                if (GlobalMethods.checkColorMatch(upperRightColor, rightNeighborUpperLeftColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether lower left color of card that I want to put on playfield matches with at least one of two neighboring cards (lower right or upper left colors)
        /// </summary>
        /// <param name="upperLeftColor">Upper left color of card that I want to put on playfield</param>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool matchLowerLeftColor(char lowerLeftColor, DataGridViewImageCell cellInput)
        {
            // check whether upper and left cell are blanc or contain card.
            string NeighborDown = (cellInput.RowIndex + 1 < dgvPlayField.RowCount) ? dgvPlayField.Rows[cellInput.RowIndex + 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;
            string NeighborLeft = (cellInput.ColumnIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex - 1].Tag.ToString() : BlancCardString;

            if (NeighborDown == silverDragonString || NeighborLeft == silverDragonString ||   // if one these 2 cards is Silver dragon card or Colorful (joker) dragon
                NeighborDown == colorfulDragonString || NeighborLeft == colorfulDragonString)
                return true;

            if (NeighborDown != BlancCardString)                                  // are the colors same?
            {
                char downNeighborUpperLeftColor = GlobalMethods.getParticularSplitCardColor(NeighborDown, 0);

                if (GlobalMethods.checkColorMatch(lowerLeftColor, downNeighborUpperLeftColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            if (NeighborLeft != BlancCardString)                                  // are the colors same?
            {
                char leftNeighborLowerRightColor = GlobalMethods.getParticularSplitCardColor(NeighborLeft, 3);

                if (GlobalMethods.checkColorMatch(lowerLeftColor, leftNeighborLowerRightColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether lower right color of card that I want to put on playfield matches with at least one of two neighboring cards (lower left or upper right colors)
        /// </summary>
        /// <param name="upperLeftColor">Upper left color of card that I want to put on playfield</param>
        /// <param name="cellInput">Cell on the playfield where I want to put the card</param>
        /// <returns></returns>
        private bool matchLowerRightColor(char lowerRightColor, DataGridViewImageCell cellInput)
        {
            // check whether upper and left cell are blanc or contain card.
            string NeighborDown = (cellInput.RowIndex + 1 < dgvPlayField.RowCount) ? dgvPlayField.Rows[cellInput.RowIndex + 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;
            string NeighborRight = (cellInput.ColumnIndex + 1 < dgvPlayField.ColumnCount) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex + 1].Tag.ToString() : BlancCardString;

            if (NeighborDown == silverDragonString || NeighborRight == silverDragonString ||   // if one these 2 cards is Silver dragon card or Colorful (joker) dragon
                NeighborDown == colorfulDragonString || NeighborRight == colorfulDragonString)
                return true;

            if (NeighborDown != BlancCardString)                                  // are the colors same?
            {
                char downNeighborUpperRightColor = GlobalMethods.getParticularSplitCardColor(NeighborDown, 1);

                if (GlobalMethods.checkColorMatch(lowerRightColor, downNeighborUpperRightColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            if (NeighborRight != BlancCardString)                                  // are the colors same?
            {
                char rightNeighborLowerLeftColor = GlobalMethods.getParticularSplitCardColor(NeighborRight, 2);

                if (GlobalMethods.checkColorMatch(lowerRightColor, rightNeighborLowerLeftColor))
                {
                    cardsToTakeFromDeck += 1;
                    return true;
                }
            }

            return false;
        }        

        private bool hasNeighboringCard(DataGridViewImageCell cellInput)
        {
            // check whether upper, loower, left and right cell are blanc or contain card.
            string NeighborUp = (cellInput.RowIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex - 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;
            string NeighborDown = (cellInput.RowIndex + 1 < dgvPlayField.RowCount) ? dgvPlayField.Rows[cellInput.RowIndex + 1].Cells[cellInput.ColumnIndex].Tag.ToString() : BlancCardString;
            string NeighborLeft = (cellInput.ColumnIndex - 1 > 0) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex - 1].Tag.ToString() : BlancCardString;
            string NeighborRight = (cellInput.ColumnIndex + 1 < dgvPlayField.ColumnCount) ? dgvPlayField.Rows[cellInput.RowIndex].Cells[cellInput.ColumnIndex + 1].Tag.ToString() : BlancCardString;

            // if there is at least one neighboring card put your card there or
            if (NeighborUp != BlancCardString || NeighborDown != BlancCardString || NeighborLeft != BlancCardString || NeighborRight != BlancCardString)                
                return true;
            else
                return false;
        }
        /// <summary>
        /// Removing card that was put on playground from player´s set
        /// </summary>       
        private void removeCardFromPlayerSet()
        {
            Image image = Image.FromFile(blancCard);
            dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Tag = BlancCardString;
            dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Value = image;

            rearrangeCardsInPlayerSet();
        }

        /// <summary>
        /// Removing card from player´s set after card rearranging 
        /// </summary>
        /// <param name="plusRow">Row increment</param>
        /// <param name="plusColumn">Column increment</param>
        private void removeCardFromPlayerSet(int plusRow, int plusColumn)
        {
            Image image = Image.FromFile(blancCard);
            dgvPlayerCards.Rows[oldPaddingRow + plusRow].Cells[oldPaddingColumn + plusColumn].Tag = BlancCardString;
            dgvPlayerCards.Rows[oldPaddingRow + plusRow].Cells[oldPaddingColumn + plusColumn].Value = image;

            oldPaddingRow = oldPaddingRow + plusRow;
            oldPaddingColumn = oldPaddingColumn + plusColumn;

            rearrangeCardsInPlayerSet();
        }

        /// <summary>
        /// If card was removed from player´s set, the gab is replaced by another card until there is no blanc card between player´s cards 
        /// </summary>
        private void rearrangeCardsInPlayerSet()
        {
            if (oldPaddingColumn + 1 < dgvPlayerCards.ColumnCount)       // cannot go outside of datagrid columns
            {
                if (dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn + 1].Tag.ToString() != BlancCardString)       // is there any next card
                {
                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Value = dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn + 1].Value;
                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Tag = dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn + 1].Tag;

                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Style.Padding = noPadding;
                   
                    getPositionForDeckCard(0, 0);              // where to put new card from deck to the set after rearranging?                         

                    removeCardFromPlayerSet(0, 1);

                    RedDragonAction.ThirdPhase = false;         // cancel third phase of red action cause card from player´s set was put on playfield
                }
                else
                {                    
                    getPositionForDeckCard(0, -1);              // where to put new card from deck to the set after rearranging?                
                }
            }
            else if (oldPaddingRow + 1 < dgvPlayerCards.RowCount)        // cannot go outside of datagrid rows
            {
                if (dgvPlayerCards.Rows[oldPaddingRow + 1].Cells[oldPaddingColumn - 2].Tag.ToString() != BlancCardString)       // is there any next card
                {
                    Image image = Image.FromFile(blancCard);

                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Value = dgvPlayerCards.Rows[oldPaddingRow + 1].Cells[oldPaddingColumn - 2].Value;
                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Tag = dgvPlayerCards.Rows[oldPaddingRow + 1].Cells[oldPaddingColumn - 2].Tag;

                    dgvPlayerCards.Rows[oldPaddingRow].Cells[oldPaddingColumn].Style.Padding = noPadding;
                    
                    getPositionForDeckCard(0, 0);              // where to put new card from deck to the set after rearranging?  

                    removeCardFromPlayerSet(1, -2);
                }
                else
                {                   
                    getPositionForDeckCard(0, -1);              // where to put new card from deck to the set after rearranging?                       
                }
            } 
        }

        private void getPositionForDeckCard(int plusRow, int plusColumn)
        {
            playerCardsRow = GridControl.recomputeRow(oldPaddingRow + plusRow, oldPaddingColumn + plusColumn);
            playerCardsColumn = GridControl.recomputeColumn(oldPaddingColumn + plusColumn);
        }

        private void BlancPlayersCardsOnPlayerGrid()
        {
            Image image = Image.FromFile(blancCard);

            for(int i = 0; i < dgvPlayerCards.RowCount; i++)
            {
                for(int j = 0; j < dgvPlayerCards.ColumnCount; j++)
                {
                    DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[i].Cells[j];

                    if((string)cellPlayerCardsInput.Tag == BlancCardString)
                        return;
                    else
                    {
                        cellPlayerCardsInput.Tag = BlancCardString;
                        cellPlayerCardsInput.Value = image;
                    }
                }
            }
        }

        private void pbCardDeck_Click(object sender, EventArgs e)
        {
            if (cards.Count != 0)       // are there cards in the deck?
            {
                int row = playerCardsRow;
                int column = playerCardsColumn;

                DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[row].Cells[column];

                string cardname = GlobalMethods.getCardFromDeck(cards);

                players[numberOfTurns % numberOfPlayers].playersCards.Add(cardname);                

                removeCard();       // remove this card from List because is in hand of player

                string fileName = stringDeckCards + cardname + ".png";               
                Image imageInput = Image.FromFile(fileName);

                cellPlayerCardsInput.ImageLayout = DataGridViewImageCellLayout.Stretch;
                cellPlayerCardsInput.Value = imageInput;
                cellPlayerCardsInput.Tag = cardname;    // name of card, https://stackoverflow.com/questions/33689250/how-do-i-get-the-bitmap-name-when-i-click-the-image-in-datagridview 
                
                playerCardsRow = GridControl.recomputeRow(row, column);
                playerCardsColumn = GridControl.recomputeColumn(column);
                             

                // if ...
                SecondPhase();

            }

            // if 3x3 grid is not enough insert another row and copy old card from last row to second last and put blanc card into last row
            // insert new row only if there are 3 rows
            if (dgvPlayerCards.Rows[2].Cells[2].Tag.ToString() != BlancCardString && dgvPlayerCards.RowCount < 4)
            {                
                addRowPlayerCards();

                Image image = Image.FromFile(blancCard);

                dgvPlayerCards.Rows[2].Cells[0].Value = dgvPlayerCards.Rows[3].Cells[0].Value;
                dgvPlayerCards.Rows[2].Cells[0].Tag = dgvPlayerCards.Rows[3].Cells[0].Tag;

                dgvPlayerCards.Rows[3].Cells[0].Value = image;
                dgvPlayerCards.Rows[3].Cells[0].Tag = BlancCardString;

                dgvPlayerCards.Rows[2].Cells[1].Value = dgvPlayerCards.Rows[3].Cells[1].Value;
                dgvPlayerCards.Rows[2].Cells[1].Tag = dgvPlayerCards.Rows[3].Cells[1].Tag;

                dgvPlayerCards.Rows[3].Cells[1].Value = image;
                dgvPlayerCards.Rows[3].Cells[1].Tag = BlancCardString;

                dgvPlayerCards.Rows[2].Cells[2].Value = dgvPlayerCards.Rows[3].Cells[2].Value;
                dgvPlayerCards.Rows[2].Cells[2].Tag = dgvPlayerCards.Rows[3].Cells[2].Tag;

                dgvPlayerCards.Rows[3].Cells[2].Value = image;
                dgvPlayerCards.Rows[3].Cells[2].Tag = BlancCardString;
            }

            // if 4x3 grid is not enough insert another row and copy old card from last row to second last and put blanc card into last row
            // insert new row only if there are 4 rows
            if (dgvPlayerCards.RowCount == 4)
            {
                if (dgvPlayerCards.Rows[3].Cells[2].Tag.ToString() != BlancCardString /*&& dgvPlayerCards.RowCount < 5*/)
                {
                    addRowPlayerCards();

                    Image image = Image.FromFile(blancCard);

                    dgvPlayerCards.Rows[3].Cells[0].Value = dgvPlayerCards.Rows[4].Cells[0].Value;
                    dgvPlayerCards.Rows[3].Cells[0].Tag = dgvPlayerCards.Rows[4].Cells[0].Tag;

                    dgvPlayerCards.Rows[4].Cells[0].Value = image;
                    dgvPlayerCards.Rows[4].Cells[0].Tag = BlancCardString;

                    dgvPlayerCards.Rows[3].Cells[1].Value = dgvPlayerCards.Rows[4].Cells[1].Value;
                    dgvPlayerCards.Rows[3].Cells[1].Tag = dgvPlayerCards.Rows[4].Cells[1].Tag;

                    dgvPlayerCards.Rows[4].Cells[1].Value = image;
                    dgvPlayerCards.Rows[4].Cells[1].Tag = BlancCardString;

                    dgvPlayerCards.Rows[3].Cells[2].Value = dgvPlayerCards.Rows[4].Cells[2].Value;
                    dgvPlayerCards.Rows[3].Cells[2].Tag = dgvPlayerCards.Rows[4].Cells[2].Tag;

                    dgvPlayerCards.Rows[4].Cells[2].Value = image;
                    dgvPlayerCards.Rows[4].Cells[2].Tag = BlancCardString;
                }
            }

            if(cardsToTakeFromDeck > 0)
            {
                cardsToTakeFromDeck -= 1;

                if(cardsToTakeFromDeck == 0)
                {
                    SecondPhase();
                    SetupForNextPlayer();
                }
            }
        }

        private void SecondPhase()
        {
            pbCardDeck.Enabled = false;
            dgvPlayerCards.Enabled = true;
        }

        private void addRowPlayerCards()
        {
            dgvPlayerCards.Rows.Add();
        }

        private void removeCard()
        {
            cards.RemoveAt(0);

            if (cards.Count == 0)   // if there is no card in deck, put particular image
            {
                Image image = Image.FromFile(blancCard);
                pbCardDeck.Image = image;
            }
        }            

        private void dgvPlayerCards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DragonAction.PickFromSet)
            {
                DataGridViewImageCell cellPlayerInput = (DataGridViewImageCell)dgvPlayerCards.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cardNameFirstLetter = cellPlayerInput.Tag.ToString();

                if (oldPaddingRow != 99 && oldPaddingColumn != 99)
                {
                    if (!((e.RowIndex == oldPaddingRow) && (e.ColumnIndex == oldPaddingColumn)))
                        DeselectCard(oldPaddingRow, oldPaddingColumn, false);
                }

                if (isPadding(e.RowIndex, e.ColumnIndex))
                {
                    DeselectCard(e.RowIndex, e.ColumnIndex, true);
                }
                else
                {
                    if (!(RedDragonAction.ThirdPhase && cardNameFirstLetter.Substring(0, 1) == "a"))       // card cannot be action card in third phase of red action
                    {
                        SelectCard(e.RowIndex, e.ColumnIndex);                                            

                        oldPaddingRow = e.RowIndex;
                        oldPaddingColumn = e.ColumnIndex;
                    }
                }
            }
        }

        private bool isPadding(int rowIndex, int columnIndex)
        {
            int topPadding = dgvPlayerCards.Rows[rowIndex].Cells[columnIndex].Style.Padding.Top;

            if (topPadding == 5)
                return true;
            else
                return false;
        }

        private bool isPaddingPlayField(int rowIndex, int columnIndex)
        {
            int topPadding = dgvPlayField.Rows[rowIndex].Cells[columnIndex].Style.Padding.Top;

            if (topPadding == 5)
                return true;
            else
                return false;
        }

        private void SelectCard(int rowIndex, int columnIndex)
        {
            DataGridViewImageCell cellPlayerInput = (DataGridViewImageCell)dgvPlayerCards.Rows[rowIndex].Cells[columnIndex];
            string cardNameSelectCard = cellPlayerInput.Tag.ToString();

            if (cardNameSelectCard != BlancCardString)                      // if there is any card
            {
                if (cardNameSelectCard.Substring(0, 1) == "a")              // if action card set red padding
                {
                    cellPlayerInput.Style = new DataGridViewCellStyle { Padding = newPadding };     // highlights edges
                    cellPlayerInput.Style.SelectionBackColor = Color.Red;
                }
                else
                    cellPlayerInput.Style = new DataGridViewCellStyle { Padding = newPadding };     // highlights edges

                oldPaddingRow = rowIndex;
                oldPaddingColumn = columnIndex;

                selectedCardImage = (Image)cellPlayerInput.Value;
                selectedCardName = cellPlayerInput.Tag.ToString();

                if (cardNameSelectCard.Substring(0, 1) == "a")          // if action card is selected, highlight silver dragon card
                {

                    highlightSilverDragonCard();
                }
            }
        }   
        
        private void highlightSilverDragonCard()
        {
            dgvPlayField.Rows[rowMiddle].Cells[columnMiddle].Style = new DataGridViewCellStyle { Padding = newPadding };
            dgvPlayField.Rows[rowMiddle].Cells[columnMiddle].Style.SelectionBackColor = Color.Red;
            dgvPlayField.Rows[rowMiddle].Cells[columnMiddle].Selected = true;
        }

        private void setHighlightOffSilverDragonCard()
        {
            dgvPlayField.Rows[rowMiddle].Cells[columnMiddle].Style = new DataGridViewCellStyle { Padding = noPadding };           
        }

        private void DeselectCard(int oldPaddingRowLocal, int oldPaddingColumnLocal, bool setOldCards)
        {
            dgvPlayerCards.Rows[oldPaddingRowLocal].Cells[oldPaddingColumnLocal].Style = new DataGridViewCellStyle { Padding = noPadding };  // set no pading for previous selected card                      
            setHighlightOffSilverDragonCard();

            if (selectedCardName != null)
            {
                if (selectedCardName.Substring(0, 1) != actionCardString)
                {
                    setCardToNull();
                }
            }

            if (setOldCards)
            {
                oldPaddingRow = 99;
                oldPaddingColumn = 99;
            }
        }

        private void setCardToNull()
        {
            selectedCardName = null;
            selectedCardImage = null;
        }

        private void dgvPlayerCards_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewImageCell cellPlayerInput = (DataGridViewImageCell)dgvPlayerCards.Rows[e.RowIndex].Cells[e.ColumnIndex];  
                string oldTag = dgvPlayerCards.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();                            
               
                Image image = (Image)cellPlayerInput.Value;
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                dgvPlayerCards.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = image;               
                selectedCardName = GlobalMethods.rotateColorsInCardName(oldTag);                        // selectedCardName is assigned to rotated colorName
                dgvPlayerCards.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = selectedCardName;            // probably redundant, important is that selectedCardName is assigned to rotated colorName
            }

            if (RedDragonAction.placeToPlayerSet_SecondPhase)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (selectedCardName != null)
                    {
                        dgvPlayerCards.Rows[playerCardsRow].Cells[playerCardsColumn].Value = selectedCardImage;
                        dgvPlayerCards.Rows[playerCardsRow].Cells[playerCardsColumn].Tag = selectedCardName;

                        setCardToNull();

                        playerCardsRow = GridControl.recomputeRow(playerCardsRow, playerCardsColumn);
                        playerCardsColumn = GridControl.recomputeColumn(playerCardsColumn);

                        //rearrangeCardsInPlayerSet();

                        RedDragonAction.takeFromPlayField_FirstPhaseRedAction = false;      // ban taking card from playfield

                        RedDragonAction.placeToPlayerSet_SecondPhase = false;       // ban place card to player set from playfield during red action
                        RedDragonAction.ThirdPhase = true;

                        removeCardFromPlayFieldAfterRedDragonAction();

                        DragonAction.PickFromSet = true;         // allow picking card from players set

                        cardsOnPlayField--;
                    }
                }
            }
        }

        private void removeCardFromPlayFieldAfterRedDragonAction()
        {
            Image image = Image.FromFile(blancCard);

            dgvPlayField.Rows[rowRedActCard].Cells[columnRedActCard].Style = new DataGridViewCellStyle { Padding = noPadding };     // set no padding

            dgvPlayField.Rows[rowRedActCard].Cells[columnRedActCard].Tag = BlancCardString;
            dgvPlayField.Rows[rowRedActCard].Cells[columnRedActCard].Value = image;
        }

        /// <summary>
        /// Yellow action -> click on opponent card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb1_Click(object sender, EventArgs e)
        {
            string objname = ((PictureBox)sender).Name;

            int opponentCardNumber = GoldDragonAction.getCardNumber(objname);

            int index = numberOfTurns % numberOfPlayers;

            // Current player cannot click on his own card
            if(players[numberOfTurns % numberOfPlayers].Position != opponentCardNumber)
            {
                if(GoldDragonAction.GoldDragonActionFlag)
                {
                    List<String> localList = new List<string>();
                    localList = PlayersColors.LinkedListToList(dragonsColors);
                    
                    int position = players[numberOfTurns % numberOfPlayers].Position;

                    string currentCard = localList[position - 1];
                    string opponentCard = localList[opponentCardNumber - 1];

                    players[numberOfTurns % numberOfPlayers].PlayerDragonColor = opponentCard;

                    for(int i = 0; i < numberOfPlayers; i++)
                    {
                        if(players[i].Position == opponentCardNumber)
                        {
                            players[i].PlayerDragonColor = currentCard;
                        }
                    }

                    localList.RemoveAt(position - 1);
                    localList.Insert(position - 1, opponentCard);

                    localList.RemoveAt(opponentCardNumber - 1);
                    localList.Insert(opponentCardNumber - 1, currentCard);

                    dragonsColors = PlayersColors.listToLinkedList(localList);

                    GoldDragonAction.GoldDragonActionFlag = false;

                    PerformCleanUpActions(index);
                }

                if(BlackDragonAction.FirstPhaseBlackDragonAction)
                {
                    bool realPlayer = IsRealPlayer(opponentCardNumber);

                    // Card changing can be performed only with real player, because he possesses cards
                    if(realPlayer)
                    {
                        List<string> CurrentPlayerCards = new List<string>();
                        List<string> ClickedPlayerCards = new List<string>();


                        int indexOfClickedPlayer = GetIndexOfClickedPlayer(opponentCardNumber);
                       

                        CurrentPlayerCards = SaveCurrentPlayersCardsDuringRotationAction();
                        ClickedPlayerCards = SaveClickedPlayersCardsDuringRotationAction(indexOfClickedPlayer);

                        GetCardsFromClickedPlayerToCurrentPlayer(ClickedPlayerCards);
                        GetCardsFromCurrentPlayerToClickedPlayer(CurrentPlayerCards, indexOfClickedPlayer);


                        BlackDragonAction.FirstPhaseBlackDragonAction = false;
                        BlackDragonAction.SecondPhaseBlackDragonActionDontSaveCards = true;

                        PerformCleanUpActions(index);
                    }
                }                
            }
        }

        private int GetIndexOfClickedPlayer(int opponentCardNumber)
        {
            int indexLocal = 0; 

            for(int i = 0; i < numberOfPlayers; i++)
            {
                if(players[i].Position == opponentCardNumber)
                {
                    indexLocal = i;                   
                }
            }

            return indexLocal;
        }

        private void PerformCleanUpActions(int index)
        {
            ShowNextPlayerDragonCard(index);

            enableClicking();
            disablePictureBoxesClicking();

            SetupForNextPlayer();
        }

        /// <summary>
        /// Transfer cards from current player to clicked player
        /// </summary>
        /// <param name="CurrentPlayerCards"></param>
        /// <param name="opponentCardNumber"></param>
        private void GetCardsFromClickedPlayerToCurrentPlayer(List<string> ClickedPlayerCards)
        {
            int currentPlayer = (numberOfTurns % numberOfPlayers);
            players[currentPlayer].playersCards.Clear();

            for(int i = 0; i < ClickedPlayerCards.Count; i++)
            {
                players[currentPlayer].playersCards.Add(ClickedPlayerCards[i]);
            }
        }

        /// <summary>
        /// Transfer cards from current player to clicked player
        /// </summary>
        /// <param name="CurrentPlayerCards"></param>
        /// <param name="opponentCardNumber"></param>
        private void GetCardsFromCurrentPlayerToClickedPlayer(List<string> CurrentPlayerCards, int indexOfClickedPlayer)
        {
            players[indexOfClickedPlayer].playersCards.Clear();

            for(int i = 0; i < CurrentPlayerCards.Count; i++)
            {
                players[indexOfClickedPlayer].playersCards.Add(CurrentPlayerCards[i]);
            }
        }

        private List<string> SaveCurrentPlayersCardsDuringRotationAction()
        {
            List<string> CurrentPlayerCardsLocal = new List<string>();

            int player = (numberOfTurns % numberOfPlayers);           

            for(int i = 0; i < dgvPlayerCards.RowCount; i++)
            {
                for(int j = 0; j < dgvPlayerCards.ColumnCount; j++)
                {
                    DataGridViewImageCell cellPlayerCardsInput = (DataGridViewImageCell)dgvPlayerCards.Rows[i].Cells[j];

                    if((string)cellPlayerCardsInput.Tag == BlancCardString)
                        break;
                    else
                    {
                        CurrentPlayerCardsLocal.Add(cellPlayerCardsInput.Tag.ToString());
                    }
                }
            }

            return CurrentPlayerCardsLocal;
        }

        private List<string> SaveClickedPlayersCardsDuringRotationAction(int indexOfClickedPlayer)
        {
            List<string> ClickedPlayerCardsLocal = new List<string>();

            int cardsCount = players[indexOfClickedPlayer].playersCards.Count;

            for(int i = 0; i < cardsCount; i++)
            {
                ClickedPlayerCardsLocal.Add(players[indexOfClickedPlayer].playersCards[i]);
            }

            return ClickedPlayerCardsLocal;

        }

        /// <summary>
        /// Check whether clicked player is real player
        /// </summary>
        /// <param name="opponentCardNumber"></param>
        /// <returns></returns>
        private bool IsRealPlayer(int opponentCardNumber)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                if(players[i].Position == opponentCardNumber)
                {
                    return true;
                }
            }

            return false;
        }

        private void enableClicking()
        {
            dgvPlayField.Enabled = true;
            pbCardDeck.Enabled = true;
            dgvPlayerCards.Enabled = true;
        }

        private void disablePictureBoxesClicking()
        {
            pb1.Enabled = false;
            pb2.Enabled = false;
            pb3.Enabled = false;
            pb4.Enabled = false;
            pb5.Enabled = false;
        }

        private void dgvPlayField_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (GreenDragonAction.takeFromPlayField_FirstPhaseGreenAction)
                {
                    DataGridViewImageCell cellPlayerInput = (DataGridViewImageCell)dgvPlayField.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string oldTag = dgvPlayField.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();

                    Image image = (Image)cellPlayerInput.Value;
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    dgvPlayField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = image;
                    selectedCardName = GlobalMethods.rotateColorsInCardName(oldTag);                        // selectedCardName is assigned to rotated colorName
                    dgvPlayField.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = selectedCardName;            // probably redundant, important is that selectedCardName is assigned to rotated colorName
                }
            }
        }

        public void UpgradeNumberOfPlayersLabel(int count)
        {
            label3.Text = count.ToString();
        }
    }      
}
