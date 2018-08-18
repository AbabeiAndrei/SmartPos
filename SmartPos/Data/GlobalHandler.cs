using System;

using SmartPos.Ui;
using SmartPos.Ui.Components;
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
                    form.PresentMessage($"{reqEx.Code} - {reqEx.StatusCode} : {reqEx.Message} ", MessageType.Error);
                    break;
                case PosException posEx:
                    form.PresentMessage($"{posEx.Code} - {posEx.Message}", MessageType.Error);
                    break;
                default:
                    form.PresentMessage(exception.Message, MessageType.Error);
                    break;
            }
        }
    }
}
