﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TeamProject
{
    public partial class MyPage : Form
    {

        string strConn = "Server=127.0.0.1; Database=teamproject; uid=project; pwd=1234; Encrypt=false";
        Admin_Page adminform;
        Main main;
        public string UserId;
        public int UserUid { get; set; }

        int MovieUid;



        public MyPage(Admin_Page form, Main main)
        {
            InitializeComponent();

            adminform = form;
            this.main = main;
            UserId = main.userid;
            UserUid = main.useruid;
            MovieUid = main.movieuid;

            myReviewView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(108, 190, 250);
            myReviewView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(108, 190, 250);
            myReviewView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            myBookmarkView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(108, 190, 250);
            myBookmarkView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(108, 190, 250);
            myBookmarkView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }

        public void MyPage_Load(object sender, EventArgs e)
        {
            ReviewView();
            BookmarkView();

            certification cert = new certification(strConn);
            SqlCommand cmd = cert.GetSqlCommand();





            if (adminform.usuid > 0)
            {
                cmd.CommandText = "SELECT u_uid,u_id, u_password, u_name, u_phonenum, u_level, u_nickname FROM project_user WHERE u_uid = @u_uid";
                cmd.Parameters.AddWithValue("@u_uid", adminform.usuid);
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {

                    idBox.Text = reader1["u_id"].ToString();
                    pwBox.Text = reader1["u_password"].ToString();
                    nameBox.Text = reader1["u_name"].ToString();
                    pnBox.Text = reader1["u_phonenum"].ToString();
                    nnBox.Text = reader1["u_nickname"].ToString();


                }

                // SqlDataReader 객체를 닫습니다.
                reader1.Close();
                return;
            }



            cmd.CommandText = "SELECT u_uid,u_id, u_password, u_name, u_phonenum, u_level, u_nickname FROM project_user WHERE u_uid = @u_uid";
            cmd.Parameters.AddWithValue("@u_uid", main.useruid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                idBox.Text = reader["u_id"].ToString();
                pwBox.Text = reader["u_password"].ToString();
                nameBox.Text = reader["u_name"].ToString();
                pnBox.Text = reader["u_phonenum"].ToString();
                nnBox.Text = reader["u_nickname"].ToString();


            }

            // SqlDataReader 객체를 닫습니다.
            modify();
            reader.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                // certification 인스턴스 생성 및 SqlCommand 객체 가져오기
                certification cert = new certification(strConn);
                SqlCommand cmd = cert.GetSqlCommand();

                // UPDATE 쿼리문 작성
                string sql = "UPDATE project_user SET u_id = @u_id, u_password = @u_password, u_name = @u_name, u_phonenum = @u_phonenum, u_nickname = @u_nickname WHERE u_uid = @u_uid";

                // SqlCommand 객체에 UPDATE 쿼리문 설정
                cmd.CommandText = sql;
                int uid;
                if (main.useruid > 0)
                    uid = main.useruid;
                else
                    uid = adminform.usuid;
                cmd.Parameters.AddWithValue("@u_uid", uid);
                // UPDATE 쿼리문의 매개변수 값 설정

                cmd.Parameters.AddWithValue("@u_id", idBox.Text);
                cmd.Parameters.AddWithValue("@u_password", pwBox.Text);
                cmd.Parameters.AddWithValue("@u_name", nameBox.Text);
                cmd.Parameters.AddWithValue("@u_phonenum", pnBox.Text);
                cmd.Parameters.AddWithValue("@u_nickname", nnBox.Text);

                // UPDATE 쿼리문 실행
                int rowsAffected = cmd.ExecuteNonQuery();
                adminform.LoadMemberView();
                adminform.Refresh();



                if (rowsAffected > 0)
                {

                    MessageBox.Show("데이터가 수정되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("데이터 수정에 실패하였습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            if (main.useruid > 0)
            {
                Main mainForm1 = new();
                {
                    Check check1 = new();

                    mainForm1.userid = check1.Findid(main.useruid);
                    mainForm1.userNickname = check1.Findnick(main.useruid);
                }
                main.Close();
                mainForm1.Main_Load_1(sender, e);
                mainForm1.Show();
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void ReviewView()
        {
            myReviewView.AllowUserToAddRows = false;

            certification cert = new certification(strConn);
            SqlCommand cmd = cert.GetSqlCommand();

            Check check = new Check();

            UserUid = check.FindUid(UserId);


            if (adminform.usuid > 0)
            {

                cmd.CommandText = $"SELECT  m.title, u.u_nickname, r.r_rate, r.r_content, r.r_date " +
                                $"FROM review r " +
                                $"INNER JOIN project_user u ON r.u_uid = u.u_uid " +
                                $"INNER JOIN MovieList M ON r.MovieUID = m.MovieUID " +
                                $"WHERE u.u_uid = {adminform.usuid}";

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                myReviewView.DataSource = dataTable;


                myReviewView.Columns["title"].HeaderText = "영화 제목";
                myReviewView.Columns["u_nickname"].HeaderText = "닉네임";
                myReviewView.Columns["r_rate"].HeaderText = "내 평점";
                myReviewView.Columns["r_content"].HeaderText = "내 리뷰";
                myReviewView.Columns["r_date"].HeaderText = "리뷰를 남긴 날짜";


                foreach (DataGridViewColumn column in myReviewView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                reader.Close();
                cmd.Dispose();
                return;
            }

            {

                cmd.CommandText = $"SELECT  m.title, u.u_nickname, r.r_rate, r.r_content, r.r_date " +
                                $"FROM review r " +
                                $"INNER JOIN project_user u ON r.u_uid = u.u_uid " +
                                $"INNER JOIN MovieList M ON r.MovieUID = m.MovieUID " +
                                $"WHERE u.u_uid = {UserUid}";

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                myReviewView.DataSource = dataTable;


                myReviewView.Columns["title"].HeaderText = "영화 제목";
                myReviewView.Columns["u_nickname"].HeaderText = "닉네임";
                myReviewView.Columns["r_rate"].HeaderText = "내 평점";
                myReviewView.Columns["r_content"].HeaderText = "내 리뷰";
                myReviewView.Columns["r_date"].HeaderText = "리뷰를 남긴 날짜";


                foreach (DataGridViewColumn column in myReviewView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                reader.Close();
                cmd.Dispose();
            }


        }


        public void BookmarkView()
        {
            myBookmarkView.AllowUserToAddRows = false;

            certification cert = new certification(strConn);
            SqlCommand cmd = cert.GetSqlCommand();

            Check check = new Check();
            UserUid = check.FindUid(UserId);

            if (adminform.usuid > 0)
            {
                cmd.CommandText = $"SELECT M.title " +
                                $"FROM Bookmark b " +
                                $"INNER JOIN project_user u ON b.u_uid = u.u_uid " +
                                $"INNER JOIN MovieList M ON b.MovieUID = m.MovieUID " +
                                $"WHERE u.u_uid = {adminform.usuid}";

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                myBookmarkView.DataSource = dataTable;

                myBookmarkView.Columns["Title"].HeaderText = "영화제목";


                foreach (DataGridViewColumn column in myBookmarkView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


                // 리소스 정리
                reader.Close();
                cmd.Dispose();
                return;
            }

            {
                cmd.CommandText = $"SELECT M.title " +
                            $"FROM Bookmark b " +
                            $"INNER JOIN project_user u ON b.u_uid = u.u_uid " +
                            $"INNER JOIN MovieList M ON b.MovieUID = m.MovieUID " +
                            $"WHERE u.u_uid = {UserUid}";

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                myBookmarkView.DataSource = dataTable;

                myBookmarkView.Columns["Title"].HeaderText = "영화제목";


                foreach (DataGridViewColumn column in myBookmarkView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


                // 리소스 정리
                reader.Close();
                cmd.Dispose();
            }
        }



        private void btn_reviewUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in myReviewView.SelectedCells)
            {
                cell.OwningRow.Selected = true;
            }

            ReviewUpdate updatePage = new ReviewUpdate(adminform, this);

            updatePage.Show();
        }

        private void btn_bmdelete_Click(object sender, EventArgs e)
        {

            Check check = new Check();
            string movietitle = myBookmarkView.SelectedCells[0].Value.ToString();
            UserUid = check.FindUid(UserId);
            MovieUid = check.FindMvUid(movietitle);

            try
            {
                if (adminform.usuid > 0)
                {
                    foreach (DataGridViewCell cell in myBookmarkView.SelectedCells)
                    {
                        cell.OwningRow.Selected = true;
                    }

                    Cursor = Cursors.WaitCursor;

                    if (myBookmarkView.SelectedRows.Count == 0) return; // 삭제하려는 row가 선택되어 있지 않으면 return


                    // 삭제전에 확인
                    if (MessageBox.Show($"{myBookmarkView.SelectedRows.Count}개의 즐겨찾기를 삭제할까요?", "삭제확인"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    { return; }

                    using SqlConnection conn = new(strConn);
                    conn.Open();

                    string sql = $"DELETE FROM Bookmark WHERE u_uid = '{adminform.usuid}' AND MovieUID = {MovieUid}; ";

                    int cnt = 0;

                    foreach (DataGridViewRow row in myBookmarkView.SelectedRows)
                    {
                        string uid = row.Cells[0].Value.ToString();  // PK 값은 첫번째 컬럼
                        using SqlCommand cmd = new(sql, conn);
                        cmd.Parameters.AddWithValue("@u_uid", uid);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            cnt += result;
                        }

                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in myBookmarkView.SelectedCells)
                    {
                        cell.OwningRow.Selected = true;
                    }

                    Cursor = Cursors.WaitCursor;

                    if (myBookmarkView.SelectedRows.Count == 0) return; // 삭제하려는 row가 선택되어 있지 않으면 return


                    // 삭제전에 확인
                    if (MessageBox.Show($"{myBookmarkView.SelectedRows.Count}개의 즐겨찾기를 삭제할까요?", "삭제확인"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    { return; }

                    using SqlConnection conn = new(strConn);
                    conn.Open();

                    string sql = $"DELETE FROM Bookmark WHERE u_uid = '{UserUid}' AND MovieUID = {MovieUid}; ";

                    int cnt = 0;

                    foreach (DataGridViewRow row in myBookmarkView.SelectedRows)
                    {
                        string uid = row.Cells[0].Value.ToString();  // PK 값은 첫번째 컬럼
                        using SqlCommand cmd = new(sql, conn);
                        cmd.Parameters.AddWithValue("@u_uid", uid);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            cnt += result;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            BookmarkView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            Check ch = new();
            i = ch.CheckID(idBox.Text);
            if (i == 1)
            { MessageBox.Show("중복검사 성공"); }
            if (i == 2)
            { MessageBox.Show("중복검사 실패"); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            idBox.ReadOnly = false;
            modify();
        }

        private void pwmodify_Click(object sender, EventArgs e)
        {
            pwBox.ReadOnly = false;
            modify();
        }

        private void nmmodify_Click(object sender, EventArgs e)
        {
            nameBox.ReadOnly = false;
            modify();
        }

        private void phnmodify_Click(object sender, EventArgs e)
        {
            pnBox.ReadOnly = false;
            modify();
        }

        private void nnmodify_Click(object sender, EventArgs e)
        {
            nnBox.ReadOnly = false;
            modify();
        }

        private void btn_reviewDelete_Click(object sender, EventArgs e)
        {

            Check check = new Check();
            string movietitle = myReviewView.SelectedCells[0].Value.ToString();
            UserUid = check.FindUid(UserId);
            MovieUid = check.FindMvUid(movietitle);

            try
            {
                if (adminform.usuid > 0)
                {

                    foreach (DataGridViewCell cell in myReviewView.SelectedCells)
                    {
                        cell.OwningRow.Selected = true;
                    }

                    Cursor = Cursors.WaitCursor;

                    if (myReviewView.SelectedRows.Count == 0) return; // 삭제하려는 row가 선택되어 있지 않으면 return


                    // 삭제전에 확인
                    if (MessageBox.Show($"{myReviewView.SelectedRows.Count}개의 리뷰를 삭제할까요?", "삭제확인"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    { return; }

                    using SqlConnection conn = new(strConn);
                    conn.Open();

                    string sql = $"DELETE FROM Review WHERE u_uid = '{adminform.usuid}' AND MovieUID = {MovieUid}; ";

                    int cnt = 0;

                    foreach (DataGridViewRow row in myReviewView.SelectedRows)
                    {
                        string uid = row.Cells[0].Value.ToString();  // PK 값은 첫번째 컬럼
                        using SqlCommand cmd = new(sql, conn);
                        cmd.Parameters.AddWithValue("@u_uid", uid);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            cnt += result;
                        }
                    }
                }
                else
                {

                    foreach (DataGridViewCell cell in myReviewView.SelectedCells)
                    {
                        cell.OwningRow.Selected = true;
                    }

                    Cursor = Cursors.WaitCursor;

                    if (myReviewView.SelectedRows.Count == 0) return; // 삭제하려는 row가 선택되어 있지 않으면 return


                    // 삭제전에 확인
                    if (MessageBox.Show($"{myReviewView.SelectedRows.Count}개의 리뷰를 삭제할까요?", "삭제확인"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    { return; }

                    using SqlConnection conn = new(strConn);
                    conn.Open();

                    string sql = $"DELETE FROM Review WHERE u_uid = '{UserUid}' AND MovieUID = {MovieUid}; ";

                    int cnt = 0;

                    foreach (DataGridViewRow row in myReviewView.SelectedRows)
                    {
                        string uid = row.Cells[0].Value.ToString();  // PK 값은 첫번째 컬럼
                        using SqlCommand cmd = new(sql, conn);
                        cmd.Parameters.AddWithValue("@u_uid", uid);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            cnt += result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            ReviewView();
        }

        private void idcom_Click(object sender, EventArgs e)
        {
            Check ch = new();
            if (ch.CheckID(idBox.Text) == 1)
            {
                MessageBox.Show("중복검사 통과");
                idBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("중복된 아이디 입니다");
                if (main.useruid > 0)
                {
                    idBox.Text = ch.Findid(UserUid);
                    idBox.ReadOnly = true;
                    modify();
                    return;
                }
                idBox.Text = ch.Findid(adminform.usuid);
                idBox.ReadOnly = true;
                modify();
            }
            modify();
        }

        private void pwcom_Click(object sender, EventArgs e)
        {
            pwBox.ReadOnly = true;
            modify();
        }

        private void nmcom_Click(object sender, EventArgs e)
        {
            nameBox.ReadOnly = true;
            modify();
        }

        private void phncom_Click(object sender, EventArgs e)
        {
            pnBox.ReadOnly = true;
            modify();
        }

        private void nmcomp_Click(object sender, EventArgs e)
        {
            nnBox.ReadOnly = true;
            modify();
        }


        public void modify()
        {
            if (idBox.ReadOnly == true &&
                pwBox.ReadOnly == true &&
                nameBox.ReadOnly == true &&
                 pnBox.ReadOnly == true &&
                 nnBox.ReadOnly == true)
            {
                button_update.Enabled = true;
            }
            else
            {
                button_update.Enabled = false;
            }
        }
    }

}
