namespace Parchis
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DiceButton = new System.Windows.Forms.Button();
            this.StartMatch = new System.Windows.Forms.Button();
            this.gameCheck = new System.Windows.Forms.Timer(this.components);
            this.turnOf = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.skipTurn = new System.Windows.Forms.Button();
            this.initialCoin = new System.Windows.Forms.CheckBox();
            this.enableRed = new System.Windows.Forms.CheckBox();
            this.enableBlue = new System.Windows.Forms.CheckBox();
            this.enableGreen = new System.Windows.Forms.CheckBox();
            this.enableYellow = new System.Windows.Forms.CheckBox();
            this.yellowCoin2 = new System.Windows.Forms.PictureBox();
            this.yellowCoin3 = new System.Windows.Forms.PictureBox();
            this.yellowCoin4 = new System.Windows.Forms.PictureBox();
            this.yellowCoin1 = new System.Windows.Forms.PictureBox();
            this.greenCoin3 = new System.Windows.Forms.PictureBox();
            this.greenCoin1 = new System.Windows.Forms.PictureBox();
            this.greenCoin4 = new System.Windows.Forms.PictureBox();
            this.greenCoin2 = new System.Windows.Forms.PictureBox();
            this.blueCoin2 = new System.Windows.Forms.PictureBox();
            this.blueCoin3 = new System.Windows.Forms.PictureBox();
            this.blueCoin4 = new System.Windows.Forms.PictureBox();
            this.blueCoin1 = new System.Windows.Forms.PictureBox();
            this.redCoin2 = new System.Windows.Forms.PictureBox();
            this.redCoin3 = new System.Windows.Forms.PictureBox();
            this.redCoin4 = new System.Windows.Forms.PictureBox();
            this.redCoin1 = new System.Windows.Forms.PictureBox();
            this.currentTurn = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.blur0 = new System.Windows.Forms.PictureBox();
            this.blur1 = new System.Windows.Forms.PictureBox();
            this.auxFicha = new System.Windows.Forms.PictureBox();
            this.diceGraph1 = new System.Windows.Forms.PictureBox();
            this.diceGraph0 = new System.Windows.Forms.PictureBox();
            this.Tablero = new System.Windows.Forms.PictureBox();
            this.blueLabel1 = new System.Windows.Forms.Label();
            this.redLabel1 = new System.Windows.Forms.Label();
            this.greenLabel1 = new System.Windows.Forms.Label();
            this.yellowLabel1 = new System.Windows.Forms.Label();
            this.consoleLogs = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blur0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blur1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auxFicha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceGraph0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // DiceButton
            // 
            this.DiceButton.Enabled = false;
            this.DiceButton.Location = new System.Drawing.Point(76, 109);
            this.DiceButton.Name = "DiceButton";
            this.DiceButton.Size = new System.Drawing.Size(140, 35);
            this.DiceButton.TabIndex = 20;
            this.DiceButton.Text = "Throw Dice";
            this.DiceButton.UseVisualStyleBackColor = true;
            this.DiceButton.Click += new System.EventHandler(this.DiceButton_Click);
            // 
            // StartMatch
            // 
            this.StartMatch.Location = new System.Drawing.Point(76, 19);
            this.StartMatch.Name = "StartMatch";
            this.StartMatch.Size = new System.Drawing.Size(140, 35);
            this.StartMatch.TabIndex = 21;
            this.StartMatch.Text = "Start Match";
            this.StartMatch.UseVisualStyleBackColor = true;
            this.StartMatch.Click += new System.EventHandler(this.StartMatch_Click);
            // 
            // gameCheck
            // 
            this.gameCheck.Tick += new System.EventHandler(this.PasaTurno_Tick);
            // 
            // turnOf
            // 
            this.turnOf.AutoSize = true;
            this.turnOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnOf.Location = new System.Drawing.Point(251, 28);
            this.turnOf.Name = "turnOf";
            this.turnOf.Size = new System.Drawing.Size(79, 17);
            this.turnOf.TabIndex = 31;
            this.turnOf.Text = "Turno de:";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(251, 52);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(12, 17);
            this.turnLabel.TabIndex = 32;
            this.turnLabel.Text = " ";
            // 
            // skipTurn
            // 
            this.skipTurn.Location = new System.Drawing.Point(254, 109);
            this.skipTurn.Name = "skipTurn";
            this.skipTurn.Size = new System.Drawing.Size(140, 35);
            this.skipTurn.TabIndex = 35;
            this.skipTurn.Text = "Skip Turn";
            this.skipTurn.UseVisualStyleBackColor = true;
            this.skipTurn.Click += new System.EventHandler(this.SkipTurn_Click);
            // 
            // initialCoin
            // 
            this.initialCoin.AutoSize = true;
            this.initialCoin.Location = new System.Drawing.Point(94, 60);
            this.initialCoin.Name = "initialCoin";
            this.initialCoin.Size = new System.Drawing.Size(111, 21);
            this.initialCoin.TabIndex = 44;
            this.initialCoin.Text = "Ficha inicial?";
            this.initialCoin.UseVisualStyleBackColor = true;
            this.initialCoin.CheckedChanged += new System.EventHandler(this.InitialCoin_CheckedChanged);
            // 
            // enableRed
            // 
            this.enableRed.AutoSize = true;
            this.enableRed.Checked = true;
            this.enableRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableRed.Location = new System.Drawing.Point(125, 192);
            this.enableRed.Name = "enableRed";
            this.enableRed.Size = new System.Drawing.Size(98, 21);
            this.enableRed.TabIndex = 68;
            this.enableRed.Text = "checkBox1";
            this.enableRed.UseVisualStyleBackColor = true;
            this.enableRed.CheckedChanged += new System.EventHandler(this.EnableRed_CheckedChanged);
            // 
            // enableBlue
            // 
            this.enableBlue.AutoSize = true;
            this.enableBlue.Checked = true;
            this.enableBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableBlue.Location = new System.Drawing.Point(299, 192);
            this.enableBlue.Name = "enableBlue";
            this.enableBlue.Size = new System.Drawing.Size(98, 21);
            this.enableBlue.TabIndex = 69;
            this.enableBlue.Text = "checkBox2";
            this.enableBlue.UseVisualStyleBackColor = true;
            this.enableBlue.CheckedChanged += new System.EventHandler(this.EnableBlue_CheckedChanged);
            // 
            // enableGreen
            // 
            this.enableGreen.AutoSize = true;
            this.enableGreen.Checked = true;
            this.enableGreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableGreen.Location = new System.Drawing.Point(125, 261);
            this.enableGreen.Name = "enableGreen";
            this.enableGreen.Size = new System.Drawing.Size(98, 21);
            this.enableGreen.TabIndex = 70;
            this.enableGreen.Text = "checkBox3";
            this.enableGreen.UseVisualStyleBackColor = true;
            this.enableGreen.CheckedChanged += new System.EventHandler(this.EnableGreen_CheckedChanged);
            // 
            // enableYellow
            // 
            this.enableYellow.AutoSize = true;
            this.enableYellow.Checked = true;
            this.enableYellow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableYellow.Location = new System.Drawing.Point(299, 261);
            this.enableYellow.Name = "enableYellow";
            this.enableYellow.Size = new System.Drawing.Size(98, 21);
            this.enableYellow.TabIndex = 71;
            this.enableYellow.Text = "checkBox4";
            this.enableYellow.UseVisualStyleBackColor = true;
            this.enableYellow.CheckedChanged += new System.EventHandler(this.EnableYellow_CheckedChanged);
            // 
            // yellowCoin2
            // 
            this.yellowCoin2.BackColor = System.Drawing.Color.Transparent;
            this.yellowCoin2.Enabled = false;
            this.yellowCoin2.Image = global::Parchis.Properties.Resources.fichaAmarilla;
            this.yellowCoin2.Location = new System.Drawing.Point(1246, 688);
            this.yellowCoin2.Name = "yellowCoin2";
            this.yellowCoin2.Size = new System.Drawing.Size(32, 32);
            this.yellowCoin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yellowCoin2.TabIndex = 8;
            this.yellowCoin2.TabStop = false;
            this.yellowCoin2.Visible = false;
            this.yellowCoin2.Click += new System.EventHandler(this.CoinClick);
            this.yellowCoin2.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.yellowCoin2.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // yellowCoin3
            // 
            this.yellowCoin3.BackColor = System.Drawing.Color.Transparent;
            this.yellowCoin3.Enabled = false;
            this.yellowCoin3.Image = global::Parchis.Properties.Resources.fichaAmarilla;
            this.yellowCoin3.Location = new System.Drawing.Point(1153, 764);
            this.yellowCoin3.Name = "yellowCoin3";
            this.yellowCoin3.Size = new System.Drawing.Size(32, 32);
            this.yellowCoin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yellowCoin3.TabIndex = 7;
            this.yellowCoin3.TabStop = false;
            this.yellowCoin3.Visible = false;
            this.yellowCoin3.Click += new System.EventHandler(this.CoinClick);
            this.yellowCoin3.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.yellowCoin3.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // yellowCoin4
            // 
            this.yellowCoin4.BackColor = System.Drawing.Color.Transparent;
            this.yellowCoin4.Enabled = false;
            this.yellowCoin4.Image = global::Parchis.Properties.Resources.fichaAmarilla;
            this.yellowCoin4.Location = new System.Drawing.Point(1246, 764);
            this.yellowCoin4.Name = "yellowCoin4";
            this.yellowCoin4.Size = new System.Drawing.Size(32, 32);
            this.yellowCoin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yellowCoin4.TabIndex = 6;
            this.yellowCoin4.TabStop = false;
            this.yellowCoin4.Visible = false;
            this.yellowCoin4.Click += new System.EventHandler(this.CoinClick);
            this.yellowCoin4.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.yellowCoin4.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // yellowCoin1
            // 
            this.yellowCoin1.BackColor = System.Drawing.Color.Transparent;
            this.yellowCoin1.Enabled = false;
            this.yellowCoin1.Image = global::Parchis.Properties.Resources.fichaAmarilla;
            this.yellowCoin1.Location = new System.Drawing.Point(1153, 688);
            this.yellowCoin1.Name = "yellowCoin1";
            this.yellowCoin1.Size = new System.Drawing.Size(32, 32);
            this.yellowCoin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yellowCoin1.TabIndex = 5;
            this.yellowCoin1.TabStop = false;
            this.yellowCoin1.Visible = false;
            this.yellowCoin1.Click += new System.EventHandler(this.CoinClick);
            this.yellowCoin1.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.yellowCoin1.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // greenCoin3
            // 
            this.greenCoin3.BackColor = System.Drawing.Color.Transparent;
            this.greenCoin3.Enabled = false;
            this.greenCoin3.Image = global::Parchis.Properties.Resources.fichaVerde;
            this.greenCoin3.Location = new System.Drawing.Point(571, 764);
            this.greenCoin3.Name = "greenCoin3";
            this.greenCoin3.Size = new System.Drawing.Size(32, 32);
            this.greenCoin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenCoin3.TabIndex = 4;
            this.greenCoin3.TabStop = false;
            this.greenCoin3.Visible = false;
            this.greenCoin3.Click += new System.EventHandler(this.CoinClick);
            this.greenCoin3.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.greenCoin3.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // greenCoin1
            // 
            this.greenCoin1.BackColor = System.Drawing.Color.Transparent;
            this.greenCoin1.Enabled = false;
            this.greenCoin1.Image = global::Parchis.Properties.Resources.fichaVerde;
            this.greenCoin1.Location = new System.Drawing.Point(571, 688);
            this.greenCoin1.Name = "greenCoin1";
            this.greenCoin1.Size = new System.Drawing.Size(32, 32);
            this.greenCoin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenCoin1.TabIndex = 3;
            this.greenCoin1.TabStop = false;
            this.greenCoin1.Visible = false;
            this.greenCoin1.Click += new System.EventHandler(this.CoinClick);
            this.greenCoin1.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.greenCoin1.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // greenCoin4
            // 
            this.greenCoin4.BackColor = System.Drawing.Color.Transparent;
            this.greenCoin4.Enabled = false;
            this.greenCoin4.Image = global::Parchis.Properties.Resources.fichaVerde;
            this.greenCoin4.Location = new System.Drawing.Point(665, 764);
            this.greenCoin4.Name = "greenCoin4";
            this.greenCoin4.Size = new System.Drawing.Size(32, 32);
            this.greenCoin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenCoin4.TabIndex = 2;
            this.greenCoin4.TabStop = false;
            this.greenCoin4.Visible = false;
            this.greenCoin4.Click += new System.EventHandler(this.CoinClick);
            this.greenCoin4.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.greenCoin4.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // greenCoin2
            // 
            this.greenCoin2.BackColor = System.Drawing.Color.Transparent;
            this.greenCoin2.Enabled = false;
            this.greenCoin2.Image = global::Parchis.Properties.Resources.fichaVerde;
            this.greenCoin2.Location = new System.Drawing.Point(665, 688);
            this.greenCoin2.Name = "greenCoin2";
            this.greenCoin2.Size = new System.Drawing.Size(32, 32);
            this.greenCoin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenCoin2.TabIndex = 1;
            this.greenCoin2.TabStop = false;
            this.greenCoin2.Visible = false;
            this.greenCoin2.Click += new System.EventHandler(this.CoinClick);
            this.greenCoin2.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.greenCoin2.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // blueCoin2
            // 
            this.blueCoin2.BackColor = System.Drawing.Color.Transparent;
            this.blueCoin2.Enabled = false;
            this.blueCoin2.Image = global::Parchis.Properties.Resources.fichaAzul;
            this.blueCoin2.Location = new System.Drawing.Point(1246, 106);
            this.blueCoin2.Name = "blueCoin2";
            this.blueCoin2.Size = new System.Drawing.Size(32, 32);
            this.blueCoin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueCoin2.TabIndex = 12;
            this.blueCoin2.TabStop = false;
            this.blueCoin2.Visible = false;
            this.blueCoin2.Click += new System.EventHandler(this.CoinClick);
            this.blueCoin2.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.blueCoin2.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // blueCoin3
            // 
            this.blueCoin3.BackColor = System.Drawing.Color.Transparent;
            this.blueCoin3.Enabled = false;
            this.blueCoin3.Image = global::Parchis.Properties.Resources.fichaAzul;
            this.blueCoin3.Location = new System.Drawing.Point(1153, 181);
            this.blueCoin3.Name = "blueCoin3";
            this.blueCoin3.Size = new System.Drawing.Size(32, 32);
            this.blueCoin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueCoin3.TabIndex = 11;
            this.blueCoin3.TabStop = false;
            this.blueCoin3.Visible = false;
            this.blueCoin3.Click += new System.EventHandler(this.CoinClick);
            this.blueCoin3.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.blueCoin3.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // blueCoin4
            // 
            this.blueCoin4.BackColor = System.Drawing.Color.Transparent;
            this.blueCoin4.Enabled = false;
            this.blueCoin4.Image = global::Parchis.Properties.Resources.fichaAzul;
            this.blueCoin4.Location = new System.Drawing.Point(1246, 181);
            this.blueCoin4.Name = "blueCoin4";
            this.blueCoin4.Size = new System.Drawing.Size(32, 32);
            this.blueCoin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueCoin4.TabIndex = 10;
            this.blueCoin4.TabStop = false;
            this.blueCoin4.Visible = false;
            this.blueCoin4.Click += new System.EventHandler(this.CoinClick);
            this.blueCoin4.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.blueCoin4.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // blueCoin1
            // 
            this.blueCoin1.BackColor = System.Drawing.Color.Transparent;
            this.blueCoin1.Enabled = false;
            this.blueCoin1.Image = global::Parchis.Properties.Resources.fichaAzul;
            this.blueCoin1.Location = new System.Drawing.Point(1153, 106);
            this.blueCoin1.Name = "blueCoin1";
            this.blueCoin1.Size = new System.Drawing.Size(32, 32);
            this.blueCoin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueCoin1.TabIndex = 9;
            this.blueCoin1.TabStop = false;
            this.blueCoin1.Visible = false;
            this.blueCoin1.Click += new System.EventHandler(this.CoinClick);
            this.blueCoin1.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.blueCoin1.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // redCoin2
            // 
            this.redCoin2.BackColor = System.Drawing.Color.Transparent;
            this.redCoin2.Enabled = false;
            this.redCoin2.Image = global::Parchis.Properties.Resources.fichaRoja;
            this.redCoin2.Location = new System.Drawing.Point(665, 106);
            this.redCoin2.Name = "redCoin2";
            this.redCoin2.Size = new System.Drawing.Size(32, 32);
            this.redCoin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redCoin2.TabIndex = 16;
            this.redCoin2.TabStop = false;
            this.redCoin2.Visible = false;
            this.redCoin2.Click += new System.EventHandler(this.CoinClick);
            this.redCoin2.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.redCoin2.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // redCoin3
            // 
            this.redCoin3.BackColor = System.Drawing.Color.Transparent;
            this.redCoin3.Enabled = false;
            this.redCoin3.Image = global::Parchis.Properties.Resources.fichaRoja;
            this.redCoin3.Location = new System.Drawing.Point(571, 181);
            this.redCoin3.Name = "redCoin3";
            this.redCoin3.Size = new System.Drawing.Size(32, 32);
            this.redCoin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redCoin3.TabIndex = 15;
            this.redCoin3.TabStop = false;
            this.redCoin3.Visible = false;
            this.redCoin3.Click += new System.EventHandler(this.CoinClick);
            this.redCoin3.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.redCoin3.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // redCoin4
            // 
            this.redCoin4.BackColor = System.Drawing.Color.Transparent;
            this.redCoin4.Enabled = false;
            this.redCoin4.Image = global::Parchis.Properties.Resources.fichaRoja;
            this.redCoin4.Location = new System.Drawing.Point(665, 181);
            this.redCoin4.Name = "redCoin4";
            this.redCoin4.Size = new System.Drawing.Size(32, 32);
            this.redCoin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redCoin4.TabIndex = 14;
            this.redCoin4.TabStop = false;
            this.redCoin4.Visible = false;
            this.redCoin4.Click += new System.EventHandler(this.CoinClick);
            this.redCoin4.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.redCoin4.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // redCoin1
            // 
            this.redCoin1.BackColor = System.Drawing.Color.Transparent;
            this.redCoin1.Enabled = false;
            this.redCoin1.Image = global::Parchis.Properties.Resources.fichaRoja;
            this.redCoin1.Location = new System.Drawing.Point(571, 106);
            this.redCoin1.Name = "redCoin1";
            this.redCoin1.Size = new System.Drawing.Size(32, 32);
            this.redCoin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redCoin1.TabIndex = 13;
            this.redCoin1.TabStop = false;
            this.redCoin1.Visible = false;
            this.redCoin1.Click += new System.EventHandler(this.CoinClick);
            this.redCoin1.MouseEnter += new System.EventHandler(this.PreviewCoin);
            this.redCoin1.MouseLeave += new System.EventHandler(this.HidePreviewCoin);
            // 
            // currentTurn
            // 
            this.currentTurn.BackColor = System.Drawing.Color.Transparent;
            this.currentTurn.Image = global::Parchis.Properties.Resources.slide2_circle_outer_yellow;
            this.currentTurn.Location = new System.Drawing.Point(488, 16);
            this.currentTurn.Name = "currentTurn";
            this.currentTurn.Size = new System.Drawing.Size(290, 288);
            this.currentTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentTurn.TabIndex = 58;
            this.currentTurn.TabStop = false;
            this.currentTurn.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Parchis.Properties.Resources.fichaAmarilla;
            this.pictureBox4.Location = new System.Drawing.Point(254, 242);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 49;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Parchis.Properties.Resources.fichaVerde;
            this.pictureBox3.Location = new System.Drawing.Point(80, 242);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Parchis.Properties.Resources.fichaAzul;
            this.pictureBox2.Location = new System.Drawing.Point(254, 173);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parchis.Properties.Resources.fichaRoja;
            this.pictureBox1.Location = new System.Drawing.Point(80, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // blur0
            // 
            this.blur0.BackColor = System.Drawing.Color.Transparent;
            this.blur0.Image = global::Parchis.Properties.Resources.flecha;
            this.blur0.Location = new System.Drawing.Point(870, 377);
            this.blur0.Name = "blur0";
            this.blur0.Size = new System.Drawing.Size(50, 50);
            this.blur0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blur0.TabIndex = 34;
            this.blur0.TabStop = false;
            this.blur0.Visible = false;
            // 
            // blur1
            // 
            this.blur1.BackColor = System.Drawing.Color.Transparent;
            this.blur1.Image = global::Parchis.Properties.Resources.flecha;
            this.blur1.Location = new System.Drawing.Point(930, 377);
            this.blur1.Name = "blur1";
            this.blur1.Size = new System.Drawing.Size(50, 50);
            this.blur1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blur1.TabIndex = 33;
            this.blur1.TabStop = false;
            this.blur1.Visible = false;
            // 
            // auxFicha
            // 
            this.auxFicha.BackColor = System.Drawing.Color.Transparent;
            this.auxFicha.Enabled = false;
            this.auxFicha.Image = global::Parchis.Properties.Resources.fichaGris;
            this.auxFicha.Location = new System.Drawing.Point(660, 533);
            this.auxFicha.Name = "auxFicha";
            this.auxFicha.Size = new System.Drawing.Size(32, 32);
            this.auxFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.auxFicha.TabIndex = 22;
            this.auxFicha.TabStop = false;
            this.auxFicha.Visible = false;
            // 
            // diceGraph1
            // 
            this.diceGraph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diceGraph1.Enabled = false;
            this.diceGraph1.Image = global::Parchis.Properties.Resources.dice1;
            this.diceGraph1.Location = new System.Drawing.Point(930, 427);
            this.diceGraph1.Name = "diceGraph1";
            this.diceGraph1.Size = new System.Drawing.Size(50, 50);
            this.diceGraph1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.diceGraph1.TabIndex = 18;
            this.diceGraph1.TabStop = false;
            this.diceGraph1.Click += new System.EventHandler(this.DiceGraph1_Click);
            // 
            // diceGraph0
            // 
            this.diceGraph0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diceGraph0.Enabled = false;
            this.diceGraph0.Image = global::Parchis.Properties.Resources.dice1;
            this.diceGraph0.Location = new System.Drawing.Point(870, 427);
            this.diceGraph0.Name = "diceGraph0";
            this.diceGraph0.Size = new System.Drawing.Size(50, 50);
            this.diceGraph0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.diceGraph0.TabIndex = 17;
            this.diceGraph0.TabStop = false;
            this.diceGraph0.Click += new System.EventHandler(this.DiceGraph0_Click);
            // 
            // Tablero
            // 
            this.Tablero.BackColor = System.Drawing.Color.Transparent;
            this.Tablero.Image = global::Parchis.Properties.Resources.Parchís;
            this.Tablero.Location = new System.Drawing.Point(475, 2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(900, 900);
            this.Tablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Tablero.TabIndex = 0;
            this.Tablero.TabStop = false;
            // 
            // blueLabel1
            // 
            this.blueLabel1.AutoSize = true;
            this.blueLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueLabel1.Location = new System.Drawing.Point(296, 173);
            this.blueLabel1.Name = "blueLabel1";
            this.blueLabel1.Size = new System.Drawing.Size(40, 17);
            this.blueLabel1.TabIndex = 78;
            this.blueLabel1.Text = "Blue";
            // 
            // redLabel1
            // 
            this.redLabel1.AutoSize = true;
            this.redLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redLabel1.Location = new System.Drawing.Point(122, 172);
            this.redLabel1.Name = "redLabel1";
            this.redLabel1.Size = new System.Drawing.Size(37, 17);
            this.redLabel1.TabIndex = 79;
            this.redLabel1.Text = "Red";
            // 
            // greenLabel1
            // 
            this.greenLabel1.AutoSize = true;
            this.greenLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenLabel1.Location = new System.Drawing.Point(122, 242);
            this.greenLabel1.Name = "greenLabel1";
            this.greenLabel1.Size = new System.Drawing.Size(53, 17);
            this.greenLabel1.TabIndex = 80;
            this.greenLabel1.Text = "Green";
            // 
            // yellowLabel1
            // 
            this.yellowLabel1.AutoSize = true;
            this.yellowLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yellowLabel1.Location = new System.Drawing.Point(296, 242);
            this.yellowLabel1.Name = "yellowLabel1";
            this.yellowLabel1.Size = new System.Drawing.Size(54, 17);
            this.yellowLabel1.TabIndex = 81;
            this.yellowLabel1.Text = "Yellow";
            // 
            // consoleLogs
            // 
            this.consoleLogs.Location = new System.Drawing.Point(26, 326);
            this.consoleLogs.Name = "consoleLogs";
            this.consoleLogs.ReadOnly = true;
            this.consoleLogs.Size = new System.Drawing.Size(423, 572);
            this.consoleLogs.TabIndex = 82;
            this.consoleLogs.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 83;
            this.label6.Text = "Console";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 910);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.consoleLogs);
            this.Controls.Add(this.yellowLabel1);
            this.Controls.Add(this.greenLabel1);
            this.Controls.Add(this.redLabel1);
            this.Controls.Add(this.blueLabel1);
            this.Controls.Add(this.enableYellow);
            this.Controls.Add(this.enableGreen);
            this.Controls.Add(this.enableBlue);
            this.Controls.Add(this.enableRed);
            this.Controls.Add(this.yellowCoin2);
            this.Controls.Add(this.yellowCoin3);
            this.Controls.Add(this.yellowCoin4);
            this.Controls.Add(this.yellowCoin1);
            this.Controls.Add(this.greenCoin3);
            this.Controls.Add(this.greenCoin1);
            this.Controls.Add(this.greenCoin4);
            this.Controls.Add(this.greenCoin2);
            this.Controls.Add(this.blueCoin2);
            this.Controls.Add(this.blueCoin3);
            this.Controls.Add(this.blueCoin4);
            this.Controls.Add(this.blueCoin1);
            this.Controls.Add(this.redCoin2);
            this.Controls.Add(this.redCoin3);
            this.Controls.Add(this.redCoin4);
            this.Controls.Add(this.redCoin1);
            this.Controls.Add(this.currentTurn);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.initialCoin);
            this.Controls.Add(this.skipTurn);
            this.Controls.Add(this.blur0);
            this.Controls.Add(this.blur1);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.turnOf);
            this.Controls.Add(this.auxFicha);
            this.Controls.Add(this.StartMatch);
            this.Controls.Add(this.DiceButton);
            this.Controls.Add(this.diceGraph1);
            this.Controls.Add(this.diceGraph0);
            this.Controls.Add(this.Tablero);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1180, 950);
            this.Name = "Main";
            this.Text = "Parchis";
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowCoin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenCoin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCoin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCoin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blur0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blur1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auxFicha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceGraph0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Tablero;
        private System.Windows.Forms.PictureBox greenCoin2;
        private System.Windows.Forms.PictureBox greenCoin4;
        private System.Windows.Forms.PictureBox greenCoin1;
        private System.Windows.Forms.PictureBox greenCoin3;
        private System.Windows.Forms.PictureBox yellowCoin1;
        private System.Windows.Forms.PictureBox yellowCoin4;
        private System.Windows.Forms.PictureBox yellowCoin3;
        private System.Windows.Forms.PictureBox yellowCoin2;
        private System.Windows.Forms.PictureBox blueCoin1;
        private System.Windows.Forms.PictureBox blueCoin4;
        private System.Windows.Forms.PictureBox blueCoin3;
        private System.Windows.Forms.PictureBox blueCoin2;
        private System.Windows.Forms.PictureBox redCoin1;
        private System.Windows.Forms.PictureBox redCoin4;
        private System.Windows.Forms.PictureBox redCoin3;
        private System.Windows.Forms.PictureBox redCoin2;
        private System.Windows.Forms.PictureBox diceGraph0;
        private System.Windows.Forms.PictureBox diceGraph1;
        private System.Windows.Forms.Button DiceButton;
        private System.Windows.Forms.Button StartMatch;
        private System.Windows.Forms.PictureBox auxFicha;
        private System.Windows.Forms.Timer gameCheck;
        private System.Windows.Forms.Label turnOf;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.PictureBox blur1;
        private System.Windows.Forms.PictureBox blur0;
        private System.Windows.Forms.Button skipTurn;
        private System.Windows.Forms.CheckBox initialCoin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox currentTurn;
        private System.Windows.Forms.CheckBox enableRed;
        private System.Windows.Forms.CheckBox enableBlue;
        private System.Windows.Forms.CheckBox enableGreen;
        private System.Windows.Forms.CheckBox enableYellow;
        private System.Windows.Forms.Label blueLabel1;
        private System.Windows.Forms.Label redLabel1;
        private System.Windows.Forms.Label greenLabel1;
        private System.Windows.Forms.Label yellowLabel1;
        private System.Windows.Forms.RichTextBox consoleLogs;
        private System.Windows.Forms.Label label6;
    }
}

