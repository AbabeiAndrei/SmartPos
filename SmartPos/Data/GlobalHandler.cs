using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.Desktop.Communication;
using SmartPos.GeneralLibrary.Exceptions;
using SmartPos.Ui;
using SmartPos.Ui.Handlers;

namespace SmartPos.Desktop.Data
{
    public static class GlobalHandler
    {
        public static void Catch(Exception exception, BaseForm form)
        {
            if (form == null)
                throw exception;

            switch (exception)
            {
                case RequestException reqEx:
                    form.ShowMessage($"{reqEx.Code} - {reqEx.StatusCode} : {reqEx.Message} ", MessageType.Error);
                    break;
                case PosException posEx:
                    form.ShowMessage($"{posEx.Code} - {posEx.Message}", MessageType.Error);
                    break;
                default:
                    form.ShowMessage(exception.Message, MessageType.Error);
                    break;
            }
        }
    }
}
