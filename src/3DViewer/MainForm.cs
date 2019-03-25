using System;
using System.Drawing;
using System.Windows.Forms;

namespace viewer
{
    public class MainForm : Form
    {
        Graphics gr;
        Pen pen1;
        View3D viewpoint;
        int ColorStep;

        private PictureBox pictureBox;
        private Label lblShift;
        private Label lblShiftX;
        private Label lblShiftY;
        private Label lblShiftZ;
        private NumericUpDown numShiftX;
        private NumericUpDown numShiftY;
        private NumericUpDown numShiftZ;
        private Label lblRotation;
        private NumericUpDown numAngleX;
        private Label lblRotationZ;
        private Label lblRotationY;
        private Label lblRotationX;
        private NumericUpDown numAngleY;
        private NumericUpDown numAngleZ;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private NumericUpDown num_scaleX;
        private NumericUpDown num_scaleY;
        private NumericUpDown num_scaleZ;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private Button btnDraw;
        private Label lblDistance;
        private NumericUpDown numDistance;
        private TextBox textBox1;
        private Button btnOpen;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.numShiftX = new System.Windows.Forms.NumericUpDown();
            this.numShiftY = new System.Windows.Forms.NumericUpDown();
            this.numShiftZ = new System.Windows.Forms.NumericUpDown();
            this.lblShiftX = new System.Windows.Forms.Label();
            this.lblShiftY = new System.Windows.Forms.Label();
            this.lblShiftZ = new System.Windows.Forms.Label();
            this.lblRotation = new System.Windows.Forms.Label();
            this.numAngleX = new System.Windows.Forms.NumericUpDown();
            this.numAngleY = new System.Windows.Forms.NumericUpDown();
            this.numAngleZ = new System.Windows.Forms.NumericUpDown();
            this.lblRotationZ = new System.Windows.Forms.Label();
            this.lblRotationY = new System.Windows.Forms.Label();
            this.lblRotationX = new System.Windows.Forms.Label();
            this.num_scaleX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_scaleY = new System.Windows.Forms.NumericUpDown();
            this.num_scaleZ = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblDistance = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(8, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 640);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // lblShift
            // 
            this.lblShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShift.Location = new System.Drawing.Point(690, 71);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(42, 16);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "Shift";
            // 
            // numShiftX
            // 
            this.numShiftX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numShiftX.Location = new System.Drawing.Point(693, 90);
            this.numShiftX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numShiftX.Name = "numShiftX";
            this.numShiftX.Size = new System.Drawing.Size(75, 20);
            this.numShiftX.TabIndex = 3;
            this.numShiftX.ValueChanged += new System.EventHandler(this.numShiftX_ValueChanged);
            // 
            // numShiftY
            // 
            this.numShiftY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numShiftY.Location = new System.Drawing.Point(693, 122);
            this.numShiftY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numShiftY.Name = "numShiftY";
            this.numShiftY.Size = new System.Drawing.Size(75, 20);
            this.numShiftY.TabIndex = 4;
            this.numShiftY.ValueChanged += new System.EventHandler(this.numShiftY_ValueChanged);
            // 
            // numShiftZ
            // 
            this.numShiftZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numShiftZ.Location = new System.Drawing.Point(693, 154);
            this.numShiftZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numShiftZ.Name = "numShiftZ";
            this.numShiftZ.Size = new System.Drawing.Size(75, 20);
            this.numShiftZ.TabIndex = 5;
            this.numShiftZ.ValueChanged += new System.EventHandler(this.numShiftZ_ValueChanged);
            // 
            // lblShiftX
            // 
            this.lblShiftX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShiftX.Location = new System.Drawing.Point(663, 90);
            this.lblShiftX.Name = "lblShiftX";
            this.lblShiftX.Size = new System.Drawing.Size(24, 24);
            this.lblShiftX.TabIndex = 6;
            this.lblShiftX.Text = "X";
            // 
            // lblShiftY
            // 
            this.lblShiftY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShiftY.Location = new System.Drawing.Point(663, 122);
            this.lblShiftY.Name = "lblShiftY";
            this.lblShiftY.Size = new System.Drawing.Size(24, 24);
            this.lblShiftY.TabIndex = 7;
            this.lblShiftY.Text = "Y";
            // 
            // lblShiftZ
            // 
            this.lblShiftZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShiftZ.Location = new System.Drawing.Point(663, 154);
            this.lblShiftZ.Name = "lblShiftZ";
            this.lblShiftZ.Size = new System.Drawing.Size(24, 24);
            this.lblShiftZ.TabIndex = 8;
            this.lblShiftZ.Text = "Z";
            // 
            // lblRotation
            // 
            this.lblRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRotation.Location = new System.Drawing.Point(690, 181);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(60, 16);
            this.lblRotation.TabIndex = 9;
            this.lblRotation.Text = "Rotation";
            // 
            // numAngleX
            // 
            this.numAngleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAngleX.DecimalPlaces = 2;
            this.numAngleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAngleX.Location = new System.Drawing.Point(693, 200);
            this.numAngleX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numAngleX.Name = "numAngleX";
            this.numAngleX.Size = new System.Drawing.Size(75, 20);
            this.numAngleX.TabIndex = 10;
            this.numAngleX.ValueChanged += new System.EventHandler(this.numAngleX_ValueChanged);
            // 
            // numAngleY
            // 
            this.numAngleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAngleY.DecimalPlaces = 2;
            this.numAngleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAngleY.Location = new System.Drawing.Point(693, 232);
            this.numAngleY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numAngleY.Name = "numAngleY";
            this.numAngleY.Size = new System.Drawing.Size(75, 20);
            this.numAngleY.TabIndex = 11;
            this.numAngleY.ValueChanged += new System.EventHandler(this.numAngleY_ValueChanged);
            // 
            // numAngleZ
            // 
            this.numAngleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAngleZ.DecimalPlaces = 2;
            this.numAngleZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAngleZ.Location = new System.Drawing.Point(693, 264);
            this.numAngleZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numAngleZ.Name = "numAngleZ";
            this.numAngleZ.Size = new System.Drawing.Size(75, 20);
            this.numAngleZ.TabIndex = 12;
            this.numAngleZ.ValueChanged += new System.EventHandler(this.numAngleZ_ValueChanged);
            // 
            // lblRotationZ
            // 
            this.lblRotationZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRotationZ.Location = new System.Drawing.Point(663, 264);
            this.lblRotationZ.Name = "lblRotationZ";
            this.lblRotationZ.Size = new System.Drawing.Size(24, 24);
            this.lblRotationZ.TabIndex = 15;
            this.lblRotationZ.Text = "Z";
            // 
            // lblRotationY
            // 
            this.lblRotationY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRotationY.Location = new System.Drawing.Point(663, 232);
            this.lblRotationY.Name = "lblRotationY";
            this.lblRotationY.Size = new System.Drawing.Size(24, 24);
            this.lblRotationY.TabIndex = 14;
            this.lblRotationY.Text = "Y";
            // 
            // lblRotationX
            // 
            this.lblRotationX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRotationX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRotationX.Location = new System.Drawing.Point(663, 200);
            this.lblRotationX.Name = "lblRotationX";
            this.lblRotationX.Size = new System.Drawing.Size(24, 24);
            this.lblRotationX.TabIndex = 13;
            this.lblRotationX.Text = "X";
            // 
            // num_scaleX
            // 
            this.num_scaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_scaleX.Location = new System.Drawing.Point(693, 315);
            this.num_scaleX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_scaleX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleX.Name = "num_scaleX";
            this.num_scaleX.Size = new System.Drawing.Size(75, 20);
            this.num_scaleX.TabIndex = 16;
            this.num_scaleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleX.ValueChanged += new System.EventHandler(this.numScaleX_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(690, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Scale";
            // 
            // num_scaleY
            // 
            this.num_scaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_scaleY.Location = new System.Drawing.Point(693, 347);
            this.num_scaleY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_scaleY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleY.Name = "num_scaleY";
            this.num_scaleY.Size = new System.Drawing.Size(75, 20);
            this.num_scaleY.TabIndex = 18;
            this.num_scaleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleY.ValueChanged += new System.EventHandler(this.numScaleY_ValueChanged);
            // 
            // num_scaleZ
            // 
            this.num_scaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_scaleZ.Location = new System.Drawing.Point(693, 379);
            this.num_scaleZ.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_scaleZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleZ.Name = "num_scaleZ";
            this.num_scaleZ.Size = new System.Drawing.Size(75, 20);
            this.num_scaleZ.TabIndex = 19;
            this.num_scaleZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_scaleZ.ValueChanged += new System.EventHandler(this.numScaleZ_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(663, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Z";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(663, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 24);
            this.label11.TabIndex = 21;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(663, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 24);
            this.label12.TabIndex = 20;
            this.label12.Text = "X";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZoomIn.Location = new System.Drawing.Point(693, 436);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 25);
            this.btnZoomIn.TabIndex = 23;
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZoomOut.Location = new System.Drawing.Point(693, 405);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(75, 25);
            this.btnZoomOut.TabIndex = 24;
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(693, 39);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 25);
            this.btnDraw.TabIndex = 29;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(693, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 25);
            this.btnOpen.TabIndex = 30;
            this.btnOpen.Text = "Open model";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDistance.Location = new System.Drawing.Point(690, 483);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(68, 16);
            this.lblDistance.TabIndex = 28;
            this.lblDistance.Text = "Distance";
            // 
            // numDistance
            // 
            this.numDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDistance.Location = new System.Drawing.Point(693, 502);
            this.numDistance.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(79, 20);
            this.numDistance.TabIndex = 27;
            this.numDistance.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDistance.ValueChanged += new System.EventHandler(this.numDist_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(662, 556);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 31;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(770, 648);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.numDistance);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.num_scaleZ);
            this.Controls.Add(this.num_scaleY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_scaleX);
            this.Controls.Add(this.lblRotationZ);
            this.Controls.Add(this.lblRotationY);
            this.Controls.Add(this.lblRotationX);
            this.Controls.Add(this.numAngleZ);
            this.Controls.Add(this.numAngleY);
            this.Controls.Add(this.numAngleX);
            this.Controls.Add(this.lblRotation);
            this.Controls.Add(this.lblShiftZ);
            this.Controls.Add(this.lblShiftY);
            this.Controls.Add(this.lblShiftX);
            this.Controls.Add(this.numShiftZ);
            this.Controls.Add(this.numShiftY);
            this.Controls.Add(this.numShiftX);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(790, 690);
            this.MinimumSize = new System.Drawing.Size(790, 690);
            this.Name = "MainForm";
            this.Text = "3D viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShiftZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }

        //=============================Drawing procedure====================

        void draw()
        {
            viewpoint.Initialize((double)numDistance.Value,
                (double)numShiftX.Value, (double)numShiftY.Value, (double)numShiftZ.Value,
                (double)numAngleX.Value, (double)numAngleY.Value, (double)numAngleZ.Value,
                (double)num_scaleX.Value, (double)num_scaleY.Value, (double)num_scaleZ.Value);

            gr = Graphics.FromImage(pictureBox.Image);
            gr.Clear(Color.DimGray);

            for (int i = 0; i < viewpoint.points.Length; i++)
            {
                int index = Math.Min(i / ColorStep, 63);
                double r = ParulaColorMap.ColorData[index, 0];
                double g = ParulaColorMap.ColorData[index, 1];
                double b = ParulaColorMap.ColorData[index, 2];

                pen1.Color = Color.FromArgb((int)r, (int)g, (int)b);
                gr.DrawEllipse(pen1, (float)viewpoint.points[i].X, (float)viewpoint.points[i].Y, 2, 2);
            }

            gr.Dispose();
            pictureBox.Invalidate();
        }

        private void numScaleX_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numScaleY_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numScaleZ_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numShiftX_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numShiftY_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numShiftZ_ValueChanged(object sender, EventArgs e) =>
            draw();
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            viewpoint.M += 10;
            draw();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            viewpoint.M -= 10;
            draw();
        }

        private void numAngleX_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numAngleY_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numAngleZ_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void numDist_ValueChanged(object sender, EventArgs e) =>
            draw();

        private void btnDraw_Click(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            //gr.Clear(Color.White);
            pen1 = new Pen(Color.Black, 2);
            draw();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "3D attractor models|*.3da|All files|*.*";
            dlg.ShowDialog();
            string fileName = dlg.FileName;

            if (!string.IsNullOrEmpty(fileName))
            {
                viewpoint = new View3D(pictureBox.Size);
                viewpoint.Read(fileName);

                ColorStep = viewpoint.points.Length / 64;
                ParulaColorMap.Init();

                textBox1.Text = TimeSpan.FromHours(-2).ToString();
            }
        }


        PointF startPoint;
        private bool grab = false;

        private PointF GetCursorLocationRelativeToPictureBox()
        {
            PointF pt = new PointF();
            pt.X = Cursor.Position.X;
            pt.Y = Cursor.Position.Y;
            pt.X -= this.Location.X;
            pt.Y -= this.Location.Y;
            pt.X += pictureBox.Location.X;
            pt.Y += pictureBox.Location.Y;

            return pt;
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            grab = true;
            startPoint = GetCursorLocationRelativeToPictureBox();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            grab = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab)
            {
                PointF ptNew = GetCursorLocationRelativeToPictureBox();

                numAngleY.Value += (decimal)(ptNew.X - startPoint.X)/10000;
                numAngleX.Value += (decimal)(ptNew.Y - startPoint.Y)/10000;
                draw();
            }

            //textBox1.Text = ptNew.ToString();
        }
    }
}
