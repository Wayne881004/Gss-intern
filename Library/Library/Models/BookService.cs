using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Models
{
    public class BookService
    {
        /// <summary>
        /// 拿BD資料
        /// </summary>        
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        /// <summary>
        /// Dropdownlist 圖書類別
        /// </summary>
        public List<SelectListItem> GetClassTable(string arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT   BOOK_CLASS_ID AS BookClassId,
		                            BOOK_CLASS_NAME AS BookClass
                             FROM BOOK_CLASS
                             ORDER BY BookClass";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapClassData(dt , arg);
        }

        private List<SelectListItem> MapClassData(DataTable dt, string arg)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["BookClass"].ToString(),
                    Value = row["BookClassId"].ToString(),
                });
            }
            return result;
        }
        /// <summary>
        /// Dropdownlist 借閱人
        /// </summary>
        public List<SelectListItem> GetUserTable(string arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT   [USER_ID] AS UserId,
		                            [USER_ENAME] AS UserEname
		                     FROM MEMBER_M";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapUserData(dt,arg);
        }

        private List<SelectListItem> MapUserData(DataTable dt, string arg)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["UserEname"].ToString(),
                    Value = row["UserId"].ToString(),
                });
            }
            return result;
        }
        /// <summary>
        /// Dropdownlist 借閱狀態
        /// </summary>
        public List<SelectListItem> GetStatusTable(string arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT   CODE_ID AS BookStatusId,
		                            CODE_NAME AS BookStatus
                             FROM BOOK_CODE
                             WHERE CODE_TYPE = 'BOOK_STATUS'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapStatusData(dt,arg);
        }

        private List<SelectListItem> MapStatusData(DataTable dt,string arg)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["BookStatus"].ToString(),
                    Value = row["BookStatusId"].ToString(),
                });
            }
            return result;
        }

        public List<Models.Library> GetBookByCondtioin(Models.LibrarySearch arg)
        {

            DataTable dt = new DataTable();
            string sql = @"SELECT   BD.BOOK_CLASS_ID AS BookClassId,
		                            BCL.BOOK_CLASS_NAME AS BookClass,
		                            BD.BOOK_ID AS BookId,
		                            BD.BOOK_NAME AS BookName,
		                            ISNULL(BD.BOOK_KEEPER, '') AS BookUserId,
		                            ISNULL(MM.USER_ENAME, '') AS BookUser,
		                            BD.BOOK_STATUS AS BookStatusId,
		                            BCO.CODE_NAME AS BookStatus,
		                            FORMAT(BD.BOOK_BOUGHT_DATE, 'yyyy/MM/dd') AS BuyDate
                            FROM BOOK_DATA AS BD
                            INNER JOIN BOOK_CLASS BCL ON BD.BOOK_CLASS_ID = BCL.BOOK_CLASS_ID
                            INNER JOIN BOOK_CODE AS BCO ON BD.BOOK_STATUS = BCO.CODE_ID AND BCO.CODE_TYPE = 'BOOK_STATUS'
                            LEFT JOIN MEMBER_M AS MM ON BD.BOOK_KEEPER = MM.[USER_ID]
                            WHERE BD.BOOK_NAME LIKE '%'+ @BookName + '%' AND
		                            BD.BOOK_CLASS_ID LIKE @BookClassId+'%' AND
		                            ISNULL(BD.BOOK_KEEPER, '') LIKE @BookUserId+'%' AND
		                            BD.BOOK_STATUS LIKE '%'+@BookStatusId+'%'
                            ORDER BY BookId";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BookName", arg.BookName == null ? string.Empty : arg.BookName));
                cmd.Parameters.Add(new SqlParameter("@BookClassId", arg.BookClassId == null ? string.Empty : arg.BookClassId));
                cmd.Parameters.Add(new SqlParameter("@BookUserId", arg.BookUserId== null ? string.Empty : arg.BookUserId));
                cmd.Parameters.Add(new SqlParameter("@BookStatusId", arg.BookStatusId == null ? string.Empty : arg.BookStatusId));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookDataToList(dt);
        }
        private List<Models.Library> MapBookDataToList(DataTable bookData)
        {
            List<Models.Library> result = new List<Library>();
            foreach (DataRow row in bookData.Rows)
            {
                result.Add(new Library()
                {
                    BookClassId = row["BookClassId"].ToString(),
                    BookClass = row["BookClass"].ToString(),
                    BookId = (int)row["BookId"],
                    BookName = row["BookName"].ToString(),
                    BookUserId = row["BookUserId"].ToString(),
                    BookUser = row["BookUser"].ToString(),
                    BookStatusId = row["BookStatusId"].ToString(),
                    BookStatus = row["BookStatus"].ToString(),
                    BuyDate = row["BuyDate"].ToString()
                });
            }
            return result;
        }
    }

}