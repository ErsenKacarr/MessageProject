﻿using MessageProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetListSenderMessage(string p);
        List<Message> GetListReceiverMessage(string p);

        List<Message> GetListDeleteMessage();
    }
}
