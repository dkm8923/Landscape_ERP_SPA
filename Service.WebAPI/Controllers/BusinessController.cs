using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEL;
using DAL.Business;
using Interfaces;

namespace Service.WebAPI.Controllers
{
    public class BusinessController : ApiController, IBusiness
    {
        private Business_DAL objDal = new Business_DAL();

        // GET api/<controller>
        public List<Business> Get()
        {
            try
            {
                List<Business> ret = objDal.Get();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public Business Get(int id)
        {
            try
            {
                Business ret = objDal.Get(id);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<controller>
        public int Post([FromBody]Business obj)
        {
            int ret = 0;

            if (ModelState.IsValid)
            {
                try
                {
                    ret = objDal.Post(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ret;
        }
    }
}
