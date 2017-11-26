using System;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dothan.Server.Hosts
{
    [WebService(Namespace = "http://ws.lhotka.net/Csla")]
    public class WebServicePortal : WebService
    {

        #region Request classes
        [Serializable()]
        public class CreateRequest
        {
            private Type _objectType;
            private object _criteria;
            private Server.DataPortalContext _context;

            /// <summary>
            /// Type of business object to create.
            /// </summary>
            public Type ObjectType
            {
                get { return _objectType; }
                set { _objectType = value; }
            }

            /// <summary>
            /// Criteria object describing business object.
            /// </summary>
            public object Criteria
            {
                get { return _criteria; }
                set { _criteria = value; }
            }

            /// <summary>
            /// Data portal context from client.
            /// </summary>
            public Server.DataPortalContext Context
            {
                get { return _context; }
                set { _context = value; }
            }
        }

        /// <summary>
        /// Request message for retrieving
        /// an existing business object.
        /// </summary>
        [Serializable()]
        public class FetchRequest
        {
            private object _criteria;
            private Server.DataPortalContext _context;

            /// <summary>
            /// Criteria object describing business object.
            /// </summary>
            public object Criteria
            {
                get { return _criteria; }
                set { _criteria = value; }
            }

            /// <summary>
            /// Data portal context from client.
            /// </summary>
            public Server.DataPortalContext Context
            {
                get { return _context; }
                set { _context = value; }
            }
        }

        /// <summary>
        /// Request message for updating
        /// a business object.
        /// </summary>
        [Serializable()]
        public class UpdateRequest
        {
            private object _object;
            private Server.DataPortalContext _context;

            /// <summary>
            /// Business object to be updated.
            /// </summary>
            public object Object
            {
                get { return _object; }
                set { _object = value; }
            }

            /// <summary>
            /// Data portal context from client.
            /// </summary>
            public Server.DataPortalContext Context
            {
                get { return _context; }
                set { _context = value; }
            }
        }


        [Serializable()]
        public class DeleteRequest
        {
            private object _criteria;
            private Server.DataPortalContext _context;

            /// <summary>
            /// Criteria object describing business object.
            /// </summary>
            public object Criteria
            {
                get { return _criteria; }
                set { _criteria = value; }
            }

            /// <summary>
            /// Data portal context from client.
            /// </summary>
            public Server.DataPortalContext Context
            {
                get { return _context; }
                set { _context = value; }
            }
        }

        #endregion


        [WebMethod()]
        public byte[] Create(byte[] requestData)
        {
            CreateRequest request = (CreateRequest)Deserialize(requestData);

            DataPortal portal = new DataPortal();
            object result;
            try
            {
                result = portal.Create(request.ObjectType, request.Criteria, request.Context);
            }
            catch (Exception ex)
            {
                result = ex;
            }
            return Serialize(result);
        }


        [WebMethod()]
        public byte[] Fetch(byte[] requestData)
        {
            FetchRequest request = (FetchRequest)Deserialize(requestData);

            DataPortal portal = new DataPortal();
            object result;
            try
            {
                result = portal.Fetch(request.Criteria, request.Context);
            }
            catch (Exception ex)
            {
                result = ex;
            }
            return Serialize(result);
        }


        [WebMethod()]
        public byte[] Update(byte[] requestData)
        {
            UpdateRequest request = (UpdateRequest)Deserialize(requestData);

            DataPortal portal = new DataPortal();
            object result;
            try
            {
                result = portal.Update(request.Object, request.Context);
            }
            catch (Exception ex)
            {
                result = ex;
            }
            return Serialize(result);
        }


        [WebMethod()]
        public byte[] Delete(byte[] requestData)
        {
            DeleteRequest request = (DeleteRequest)Deserialize(requestData);

            DataPortal portal = new DataPortal();
            object result;
            try
            {
                result = portal.Delete(request.Criteria, request.Context);
            }
            catch (Exception ex)
            {
                result = ex;
            }
            return Serialize(result);
        }

        #region Helper functions

        private static byte[] Serialize(object obj)
        {
            if (obj != null)
            {
                using (MemoryStream buffer = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(buffer, obj);
                    return buffer.ToArray();
                }
            }
            return null;
        }

        private static object Deserialize(byte[] obj)
        {
            if (obj != null)
            {
                using (MemoryStream buffer = new MemoryStream(obj))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(buffer);
                }
            }
            return null;
        }

        #endregion
    }
}
