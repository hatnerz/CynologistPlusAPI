namespace WebAPI.Others
{
    namespace GlobalEnums
    {
        public enum RegistrationResult
        {
            Success,
            LoginExists,
            EmailExists,
            OtherError
        }

        public enum ChangePasswordResult
        {
            Success,
            UserNotFound,
            IncorrectOldPassword,
            NewPasswordEqualsOld
        }

        public enum DeletingResult
        {
            Success,
            ItemNotFound,
            AccessDenied
        }

        public enum CreationResult
        {
            Success,
            IncorrectRefference,
            IncorrectData,
            OtherError
        }

        public enum ModifyResult
        {
            Success,
            IncorrectRefference,
            IncorrectData,
            OtherError
        }
    }
}
