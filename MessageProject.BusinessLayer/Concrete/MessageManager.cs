using MessageProject.BusinessLayer.Abstract;
using MessageProject.DataAccessLayer.Abstravt;
using MessageProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListDeleteMessage()
        {
            return _messageDal.GetByFilter(x => x.Status == false);
        }

        public List<Message> GetListReceiverMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.ReceiverMail == p);

        }

        public List<Message> GetListSenderMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.SenderMail == p);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetList();
        }

        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
