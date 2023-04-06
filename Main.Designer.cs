﻿namespace TeamProject
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSearch = new Button();
            btnLogin = new Button();
            label4 = new Label();
            fLPMain = new FlowLayoutPanel();
            mypage = new Button();
            dTPStart = new DateTimePicker();
            dTPEnd = new DateTimePicker();
            txtName = new TextBox();
            CB_Category = new ComboBox();
            label_nn = new Label();
            label5 = new Label();
            panel1 = new Panel();
            label_id = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(200, 100);
            flowLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(108, 160, 220);
            label1.Location = new Point(152, 100);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "날짜 시작";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(108, 160, 220);
            label2.Location = new Point(345, 100);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "날짜 끝";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(108, 160, 220);
            label3.Location = new Point(533, 100);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "영화이름 검색";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(108, 160, 220);
            btnSearch.FlatAppearance.BorderColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(823, 116);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(70, 24);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(108, 160, 220);
            btnLogin.FlatAppearance.BorderColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(823, 88);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(70, 25);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(108, 160, 220);
            label4.Location = new Point(9, 100);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 9;
            label4.Text = "카테고리 선택";
            // 
            // fLPMain
            // 
            fLPMain.AutoScroll = true;
            fLPMain.BackColor = Color.FromArgb(242, 242, 241);
            fLPMain.Location = new Point(9, 144);
            fLPMain.Margin = new Padding(2);
            fLPMain.Name = "fLPMain";
            fLPMain.Size = new Size(950, 358);
            fLPMain.TabIndex = 12;
            // 
            // mypage
            // 
            mypage.BackColor = Color.FromArgb(108, 190, 250);
            mypage.FlatAppearance.BorderColor = Color.FromArgb(108, 190, 250);
            mypage.FlatStyle = FlatStyle.Flat;
            mypage.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            mypage.ForeColor = Color.White;
            mypage.Location = new Point(815, 32);
            mypage.Margin = new Padding(2);
            mypage.Name = "mypage";
            mypage.Size = new Size(78, 26);
            mypage.TabIndex = 13;
            mypage.Text = "마이페이지";
            mypage.UseVisualStyleBackColor = false;
            mypage.Visible = false;
            mypage.Click += mypage_Click;
            // 
            // dTPStart
            // 
            dTPStart.Location = new Point(152, 117);
            dTPStart.Margin = new Padding(2);
            dTPStart.Name = "dTPStart";
            dTPStart.Size = new Size(190, 23);
            dTPStart.TabIndex = 14;
            // 
            // dTPEnd
            // 
            dTPEnd.Location = new Point(345, 117);
            dTPEnd.Margin = new Padding(2);
            dTPEnd.Name = "dTPEnd";
            dTPEnd.Size = new Size(190, 23);
            dTPEnd.TabIndex = 15;
            // 
            // txtName
            // 
            txtName.Location = new Point(537, 117);
            txtName.Margin = new Padding(2);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "검색할 영화이름을 입력하세요";
            txtName.Size = new Size(264, 23);
            txtName.TabIndex = 16;
            // 
            // CB_Category
            // 
            CB_Category.FormattingEnabled = true;
            CB_Category.Items.AddRange(new object[] { "매출액 순서", "오름차순", "내림차순", "최신 작품순", "예전 작품순", "별점 높은순", "별점 낮은순" });
            CB_Category.Location = new Point(9, 116);
            CB_Category.Margin = new Padding(2);
            CB_Category.Name = "CB_Category";
            CB_Category.Size = new Size(142, 23);
            CB_Category.TabIndex = 17;
            CB_Category.SelectedValueChanged += CB_Category_SelectedIndexChanged_1;
            // 
            // label_nn
            // 
            label_nn.AutoSize = true;
            label_nn.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_nn.ForeColor = Color.White;
            label_nn.Location = new Point(673, 35);
            label_nn.Margin = new Padding(2, 0, 2, 0);
            label_nn.Name = "label_nn";
            label_nn.Size = new Size(0, 15);
            label_nn.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(401, 19);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(134, 37);
            label5.TabIndex = 20;
            label5.Text = "영화 리뷰";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(108, 160, 220);
            panel1.Controls.Add(label_id);
            panel1.Controls.Add(label_nn);
            panel1.Controls.Add(mypage);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(959, 84);
            panel1.TabIndex = 21;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_id.ForeColor = Color.White;
            label_id.Location = new Point(626, 35);
            label_id.Margin = new Padding(2, 0, 2, 0);
            label_id.Name = "label_id";
            label_id.Size = new Size(0, 15);
            label_id.TabIndex = 18;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(959, 513);
            Controls.Add(btnLogin);
            Controls.Add(panel1);
            Controls.Add(CB_Category);
            Controls.Add(txtName);
            Controls.Add(dTPEnd);
            Controls.Add(dTPStart);
            Controls.Add(fLPMain);
            Controls.Add(label4);
            Controls.Add(btnSearch);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSearch;
        private Button btnLogin;
        private Label label4;
        private FlowLayoutPanel fLPMain;
        private Button mypage;
        private DateTimePicker dTPStart;
        private DateTimePicker dTPEnd;
        private TextBox txtName;
        private ComboBox CB_Category;
        private Label lable_id;
        private Label lable_nickname;
        private Label label_nn;
        private Label label5;
        private Panel panel1;
        private Label label_id;
    }
}