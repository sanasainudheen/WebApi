using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Test_WebApi.Context;
using Test_WebApi.Data;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var records = await _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                name = x.name,
                emailId = x.emailId,
                userName = x.userName,
                password = DecryptString(x.password)
            }).ToListAsync();
            return records;
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var records = await _context.Users.Where(x => x.Id == userId).Select(x => new UserModel()
            {
                Id = x.Id,
                name = x.name,
                emailId = x.emailId,
                userName = x.userName,
                password =DecryptString(x.password)
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddUserAsync(UserModel userModel)
        {
            var records = await _context.Users.Where(x => x.userName == userModel.userName).Select(x => new UserModel()
            {
                Id = x.Id,
                name = x.name,
                emailId = x.emailId,
                userName = x.userName,
                password = DecryptString(x.password)
            }).FirstOrDefaultAsync();

            if(records == null) { 


            var user = new User
            {
                name = userModel.name,
                emailId = userModel.emailId,
                userName = userModel.userName,
                password =EncryptString(userModel.password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
                }
            else
            {
                return 0;
            }
        }
        public async Task<int> UpdateUserAsync(int userId, UserModel userModal)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.name = userModal.name;
                user.emailId = userModal.emailId;
                user.userName = userModal.userName;
                user.password = userModal.password;
                await _context.SaveChangesAsync();
            }
            return userId;
        }
        public async Task DeleteUserAsync(int userID)
        {
            var user = new User() { Id = userID };
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }
        private static string key = "b14ca5898a4e4142aace2ea2143a2410";
        public static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }
        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);//I have already defined "Key" in the above EncryptString function
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
