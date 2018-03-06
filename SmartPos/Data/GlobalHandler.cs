using System;

using SmartPos.Ui;
using SmartPos.Ui.Handlers;
using SmartPos.Desktop.Communication;
using SmartPos.GeneralLibrary.Exceptions;

namespace SmartPos.Desktop.Data
{
    public static class GlobalHandler
    {
        public static void Catch(Exception exception)
        {
            Catch(exception, Application.MainForm);
        }

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
