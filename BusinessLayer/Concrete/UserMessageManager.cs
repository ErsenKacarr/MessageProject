using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        //public List<UserMessage> GetUserMessageWith()
        //{
        //    return _userMessageDal.GetUserMessagesWithUser();
        //}

        public List<UserMessage> GetListReceiverMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.Receiver == p);
        }

        public List<UserMessage> GetListSenderMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.Sender == p);
        }

        public List<UserMessage> GetUserMessageWith()
        {
            throw new NotImplementedException();
        }

        public void TDelete(UserMessage t)
        {
            throw new NotImplementedException();
        }

        public UserMessage TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserMessage> TGetList()
        {
            throw new NotImplementedException();
        }
        
        public List<UserMessage> TGetListbyFilter(string p)
        {
            return _userMessageDal.GetByFilter(x => x.Receiver == p);
        }

        public List<UserMessage> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TInsert(UserMessage t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(UserMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
