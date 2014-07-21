// -----------------------------------------------------------------------
// <copyright file="MessageClient.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    using Config = ClientConfiguration;

    /// <summary>
    /// Yammer messages client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-messages
    /// </remarks>
    public class MessageClient : ClientBase, IMessageClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public MessageClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get all public messages in the User's network. 
        /// Corresponds to "All" conversations in the Yammer web interface.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetAll(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get the User's feed based on the selection made between "Following" and "Top" conversation.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetFeed(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/my_feed.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get the algorithmic feed that corresponds to "Top" conversation.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetTop(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/algo.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get the "Following" feed which is conversations involving people, groups and topics that the user is following. 
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetFollowing(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/following.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get all messages sent by the User. 
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetSent(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/sent.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get all private messages received by the User.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetPrivate(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/private.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Get all messages received by the User.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public async Task<IQueryable<Message>> GetReceived(int limit = Config.Message.DefaultLimit, MessageQueryTrim trim = null, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(limit, trim, thread);
            var url = this.GetFinalUrl(string.Format("{0}/received.json", Endpoints.Messages), query.SerializeQueryString());
            var result = await this.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }

        /// <summary>
        /// Marks the specified message as liked by the current user.
        /// </summary>
        /// <param name="id">The message id to like.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task LikeById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/liked_by/current.json?message_id={1}", Endpoints.Messages, id));

            await this.Client.PostAsync(url);
        }

        /// <summary>
        /// Removes the like mark from the specified message.
        /// </summary>
        /// <param name="id">The message id to unlike.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task UnlikeById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/liked_by/current.json?message_id={1}", Endpoints.Messages, id));

            await this.Client.DeleteAsync(url);
        }

        /// <summary>
        /// Remove a message by its id. The message must be owned by the current user.
        /// </summary>
        /// <param name="id">The message id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/{1}", Endpoints.Messages, id));

            await this.Client.DeleteAsync(url);
        }
    }

    /// <summary>
    /// The MessageClient query helper.
    /// </summary>
    internal class MessageQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQuery"/> class.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="threaded">The message thread option.</param>
        /// <param name="excludeOwnMessages"></param>
        /// <param name="includeCounts"></param>
        public MessageQuery(
            int limit,
            MessageQueryTrim trim,
            MessageQueryThread threaded)
        {
            if (limit > 0
                && limit != Config.Message.DefaultLimit)
            {
                this.Limit = limit;
            }

            if (trim != null)
            {
                switch (trim.TrimOption)
                {
                    case MessageQueryTrimOption.OlderThan:
                        this.Older_Than = trim.MessageId;
                        break;

                    case MessageQueryTrimOption.NewerThan:
                        this.Newer_Than = trim.MessageId;
                        break;
                }
            }

            switch (threaded)
            {
                case MessageQueryThread.Threaded:
                    this.Threaded = "true";
                    break;

                case MessageQueryThread.Extended:
                    this.Threaded = "extended";
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <remarks>
        /// Return only the specified number of messages. Works for threaded and extended threaded messages.
        /// </remarks>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the older than trim.
        /// </summary>
        public long? Older_Than { get; set; }

        /// <summary>
        /// Gets or sets the newer than trim.
        /// </summary>
        public long? Newer_Than { get; set; }

        /// <summary>
        /// Gets or sets the thread option.
        /// </summary>
        public string Threaded { get; set; }
    }

    /// <summary>
    /// The message retrieval trim options.
    /// </summary>
    public class MessageQueryTrim
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueryTrim"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="option">The option.</param>
        public MessageQueryTrim(Message message, MessageQueryTrimOption option)
        {
            this.MessageId = message.Id;
            this.TrimOption = option;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueryTrim"/> class.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <param name="option">The option.</param>
        public MessageQueryTrim(long messageId, MessageQueryTrimOption option)
        {
            this.MessageId = messageId;
            this.TrimOption = option;
        }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// Gets or sets the trim option.
        /// </summary>
        public MessageQueryTrimOption TrimOption { get; set; }
    }

    /// <summary>
    /// The message retrieval trim options.
    /// </summary>
    public enum MessageQueryTrimOption
    {
        /// <summary>
        /// Retrieve all messages.
        /// </summary>
        NoTrim,

        /// <summary>
        /// Only retrieve messages older than a particular message.
        /// </summary>
        OlderThan,

        /// <summary>
        /// Only retrieve messages newer than a particular message.
        /// </summary>
        NewerThan
    }

    /// <summary>
    /// The message thread options.
    /// </summary>
    public enum MessageQueryThread
    {
        /// <summary>
        /// No threaded messages.
        /// </summary>
        NoThread,

        /// <summary>
        /// Only return the first message in each thread.
        /// </summary>
        Threaded,

        /// <summary>
        /// Return all messages in the thread.
        /// </summary>
        Extended
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Messages endpoint.
        /// </summary>
        public const string Messages = "/messages";
    }

    /// <summary>
    /// The shared client configuration.
    /// </summary>
    internal static partial class ClientConfiguration
    {
        /// <summary>
        /// The MessageClient configuration.
        /// </summary>
        internal static class Message
        {
            /// <summary>
            /// The default query limit.
            /// </summary>
            public const int DefaultLimit = 0;
        }
    }
}
