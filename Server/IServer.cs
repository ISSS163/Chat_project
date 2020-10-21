using System;
using System.Collections.Generic;

namespace Server
{


    public interface IServer
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Идентификатор сессии</returns>
        /// <remarks>После регистрации пользователь считается вошедшим в систему</remarks>
        Guid Register(RegistrationInfo user);

        /// <summary>
        /// Обновление информации о текущем пользователе
        /// </summary>
        /// <param name="info"></param>
        void UpdateUserInfo(UserInfo info);

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Идентификатор сессии</returns>
        Guid Login(string username, string password);

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Guid Logout(Guid sessionId);

        /// <summary>
        /// Получение списка диалогов текущего пользователя
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        List<DialogInfo> GetDialogs(Guid sessionId);

        /// <summary>
        /// Получение списка сообщений из диалога
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="dialodId">Идентификатор диалога</param>
        /// <param name="start">Нормер стартового сообщения (начиная с конца списка)</param>
        /// <param name="count">Число запрашиваемых сообщений</param>
        /// <returns></returns>
        /// <remarks>Для того, чтобы запросить 10 последних сообщений, нужно передать start=0 и count=10.</remarks>
        /// /// <remarks>Для того, чтобы запросить 20 следующих сообщений, нужно передать start=10 и count=20.</remarks>
        List<Message> GetMessages(Guid sessionId, Guid dialodId, int start, int count);

        /// <summary>
        /// Проверка наличия новых сообщений
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>TODO</returns>
        /// <remarks>Возможно, достаточно вернуть bool (true или false)?</remarks>
        /// <remarks>Или список диалогов с новыми сообщениями?</remarks>
        /// <remarks>Или более подробную инфу (диалоги+сообщения)?</remarks>
        NewMessagesInfo HasNewMessages(Guid sessionId);

        /// <summary>
        /// Поиск сообщения в текущем диалоге
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="dialogId">Идентификатор диалога</param>
        /// <param name="searchStr">Строка поиска</param>
        /// <returns>Список подходящих сообщений</returns>
        List<Message> Search(Guid sessionId, Guid dialogId, string searchStr);

        /// <summary>
        /// Поиск сообщений в текущем диалоге по дате
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="dialogId">Идентификатор диалога</param>
        /// <param name="date">Дата</param>
        /// <returns>Список подходящих сообщений</returns>
        List<Message> Search(Guid sessionId, Guid dialogId, DateTime date);

        /// <summary>
        /// Поиск сообщений по всем диалогам
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="searchStr">Строка поиска</param>
        /// <returns>Список подходящих сообщений</returns>
        List<Message> SearchAll(Guid sessionId, string searchStr);

        /// <summary>
        /// Поиск пользователя
        /// </summary>
        /// <param name="searchStr">Строка поиска</param>
        /// <returns>Список подходящих пользователей</returns>
        /// <remarks>По каким полям искать - Username, FirstName, LastName?</remarks>
        /// <remarks>Возможно, стоит добавить еще методы для поиска по разным полям?</remarks>
        /// <remarks>Или добавить какой-нибудь enum UserSearchMethod?</remarks>
        List<UserInfo> FindUser(string searchStr);

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="msg">Сообщение</param>
        void SendMessage(Guid sessionId, Message msg);
    }
}
