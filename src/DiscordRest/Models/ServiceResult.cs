namespace DiscordRest.Models
{
    /// <summary>
    /// The response after a service operation.
    /// </summary>
    public class ServiceResult
    {
        private ServiceResult()
        {
            Succeeded = true;
            Code = string.Empty;
            Message = string.Empty;

        }

        private ServiceResult(string code, string message)
        {
            Succeeded = false;
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Indicates if service operation succeeded
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// The error code returned if the service operation failed.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The error message returned if the service operation failed.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Invoke to create a successful service result.
        /// </summary>
        public static ServiceResult Success => new ServiceResult();

        /// <summary>
        /// Invoke to create a failed service result.
        /// </summary>
        /// <param name="code">Error code to return</param>
        /// <param name="message">Message to return</param>
        /// <returns></returns>
        public static ServiceResult Failed(string code, string message)
        {
            return new ServiceResult(code, message);
        }
    }
}
    