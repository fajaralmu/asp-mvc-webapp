﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrgWebMvc.Models;

namespace OrgWebMvc.Main.Service
{
    public class PostService
        : BaseService
    {
        
        public override List<object> ObjectList(int offset, int limit)
        {
            List<object> ObjList = new List<object>();
            var Sql = (from p in dbEntities.posts orderby p.title select p);
            List<post> List = Sql.Skip(offset * limit).Take(limit).ToList();
            foreach (post c in List)
            {
                ObjList.Add(c);
            }
            count = dbEntities.posts.Count();
            return ObjList;
        }
        public override object Update(object Obj)
        {
            Refresh();
            post post = (post)Obj;
            post DBpost = (post)GetById(post.id);
            if (DBpost == null)
            {
                return null;
            }
            dbEntities.Entry(DBpost).CurrentValues.SetValues(post);
            dbEntities.SaveChanges();
            return post;
        }

        public override object GetById(object Id)
        {
            post post = (from c in dbEntities.posts where c.id==(int)Id select c).SingleOrDefault();
            return post;
        }

        public override void Delete(object Obj)
        {
            post post = (post)Obj;
            dbEntities.posts.Remove(post);
            dbEntities.SaveChanges();
        }


        

        public override int ObjectCount()
        {
            return count;// dbEntities.posts.Count();
        }

        public override object Add(object Obj)
        {
            post post = (post)Obj;
           
            post newpost = dbEntities.posts.Add(post);
            try
            {
                dbEntities.SaveChanges();
                return newpost;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
                //  return null;
            }

        }

        private List<object> ListWithSql(string sql, int limit = 0, int offset = 0)
        {
            List<object> categoryList = new List<object>();
            var posts = dbEntities.posts
                .SqlQuery(sql
                ).
                Select(post => new
                {
                    post
                });
            if (limit > 0)
            {
                posts = posts.Skip(offset * limit).Take(limit).ToList();
            }
            else
            {
                posts = posts.ToList();
            }
            foreach (var u in posts)
            {
                post post = u.post;
                categoryList.Add(post);
            }

            return categoryList;
        }

        public override List<object> SearchAdvanced(Dictionary<string, object> Params, int limit = 0, int offset = 0)
        {

            string id = Params.ContainsKey("id") ? (string)Params["id"] : "";
            string title = Params.ContainsKey("title") ? (string)Params["title"] : "";
            string orderby = Params.ContainsKey("orderby") ? (string)Params["orderby"] : "";
            string ordertype = Params.ContainsKey("ordertype") ? (string)Params["ordertype"] : "";

            string sql = "select * from post where id like '%" + id + "%'" +
                " and title like '%" + title + "%'";
            if (!orderby.Equals(""))
            {
                sql += " ORDER BY " + orderby;
                if (!ordertype.Equals(""))
                {
                    sql += " " + ordertype;
                }
            }
            count = countSQL(sql, dbEntities.posts);
            return ListWithSql(sql, limit, offset);
        }


        public override int countSQL(string sql, object dbSet)
        {
            return ((DbSet<post>)dbSet)
                .SqlQuery(sql).Count();
        }

    }
}