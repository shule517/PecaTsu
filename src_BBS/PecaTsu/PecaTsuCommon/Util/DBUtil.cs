using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PecaTsuCommon.Util
{
    public class DBUtil
    {
        /// <summary>
        /// DBコネクション
        /// </summary>
        static MySqlConnection connection;

        /// <summary>
        /// DB接続
        /// </summary>
        public static void Connect()
        {
            StreamReader sr = new StreamReader(@"Settings/DBAccess.txt", Encoding.GetEncoding("Shift_JIS"));
            string connectionData = sr.ReadToEnd();
            connection = new MySqlConnection(connectionData);
            connection.Open();
        }

        /// <summary>
        /// DB検索(SELECT)
        /// </summary>
        /// <typeparam name="Type">Entityの型</typeparam>
        /// <param name="sql">SQL文</param>
        /// <returns>SELECT結果</returns>
        public static List<Type> Select<Type>(string sql)
            where Type : new()
        {
            List<Type> entityList = new List<Type>();

            MySqlCommand command = new MySqlCommand(sql, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                // Entityクラス情報を取得
                PropertyInfo[] properties = typeof(Type).GetProperties();

                // 取得レコードの解析
                while (reader.Read())
                {
                    Type entity = new Type();
                    GetRecord(reader, properties, entity);
                    entityList.Add(entity);
                }
            }

            return entityList;
        }

        /// <summary>
        /// レコードのデータ取得
        /// </summary>
        /// <param name="reader">SQLReader</param>
        /// <param name="properties">Entityのプロパティ情報</param>
        /// <param name="entity">Entity情報</param>
        private static void GetRecord(MySqlDataReader reader, PropertyInfo[] properties, object entity)
        {
            List<string> data = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string dbColumnName = reader.GetName(i);
                PropertyInfo property = properties.Where(elem => elem.Name == dbColumnName).Single();

                if (property.PropertyType == typeof(string))
                {
                    string value = reader.GetString(i);
                    property.SetValue(entity, value);
                }
                else if (property.PropertyType == typeof(int))
                {
                    int value = reader.GetInt32(i);
                    property.SetValue(entity, value);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    DateTime value = reader.GetDateTime(i);
                    property.SetValue(entity, value);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    bool value = reader.GetBoolean(i);
                    property.SetValue(entity, value);
                }
                else
                {
                    throw new Exception("対応していない型(" + reader.GetDataTypeName(i) + ":" + dbColumnName + ")を取得しました。");
                }

                data.Add(reader.GetString(i));
            }
        }
    }
}
