using System;
using System.Collections.Generic;

namespace Social_Media_Friend_Connections
{
    class Program
    {
        static void Main(string[] args)
        {
            FriendNetwork socialNetwork = new FriendNetwork();
            while (true)
            {
                Console.WriteLine("\n--- Social Media Friend System ---");
                Console.WriteLine("1. Add a User");
                Console.WriteLine("2. Add a Friend Connection");
                Console.WriteLine("3. Remove a Friend Connection");
                Console.WriteLine("4. Find Mutual Friends");
                Console.WriteLine("5. Display All Friends of a User");
                Console.WriteLine("6. Search for a User");
                Console.WriteLine("7. Count Friends for Each User");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter User ID: ");
                        string userId = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        socialNetwork.AddUser(userId, name, age);
                        break;
                    case 2:
                        Console.Write("Enter First User ID: ");
                        string id1 = Console.ReadLine();
                        Console.Write("Enter Second User ID: ");
                        string id2 = Console.ReadLine();
                        socialNetwork.AddFriend(id1, id2);
                        break;
                    case 3:
                        Console.Write("Enter First User ID: ");
                        string removeId1 = Console.ReadLine();
                        Console.Write("Enter Second User ID: ");
                        string removeId2 = Console.ReadLine();
                        socialNetwork.RemoveFriend(removeId1, removeId2);
                        break;
                    case 4:
                        Console.Write("Enter First User ID: ");
                        string mutualId1 = Console.ReadLine();
                        Console.Write("Enter Second User ID: ");
                        string mutualId2 = Console.ReadLine();
                        socialNetwork.FindMutuals(mutualId1, mutualId2);
                        break;
                    case 5:
                        Console.Write("Enter User ID: ");
                        string displayId = Console.ReadLine();
                        socialNetwork.DisplayFriends(displayId);
                        break;
                    case 6:
                        Console.Write("Enter User ID or Name: ");
                        string searchQuery = Console.ReadLine();
                        socialNetwork.SearchUser(searchQuery);
                        break;
                    case 7:
                        socialNetwork.CountFriends();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
    class User
    {
        public string UserId { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<User> Friends {  get; set; }
        public User Next;

        public User(string userId, string name, int age)
        {
            UserId = userId;
            Name = name;
            Age = age;
            Friends = new List<User>();
            Next = null;
        }
    }
    class FriendNetwork
    {
        private User head = null;
        //Add a new User
        public void AddUser(string userId, string name, int age)
        {
            if (FindUserById(userId) != null)
            {
                Console.WriteLine("User already exists");
                return;
            }
            User newUser = new User(userId, name, age);
            if (head == null)
            {
                head = newUser;
            }
            else
            {
                User temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newUser;
            }
            Console.WriteLine($"User {name} added successfully");
        }
        // Find user by ID
        private User FindUserById(string userId)
        {
            User temp = head;
            while (temp != null)
            {
                if (temp.UserId == userId)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            return null;
        }

        //Add a friend connection between two users
        public void AddFriend(string userId1, string userId2)
        {
            User user1 = FindUserById(userId1);
            User user2 = FindUserById(userId2);

            if (user1 == null || user2 == null)
            {
                Console.WriteLine("One or both user not found");
                return;
            }
            if (!user1.Friends.Contains(user2))
            {
                user1.Friends.Add(user2);
            }
            if (!user2.Friends.Contains(user1))
            {
                user2.Friends.Add(user1);
            }
            Console.WriteLine($"Friend connection added between {user1.Name} and {user2.Name}");
        }

        // Remove a friend connection
        public void RemoveFriend(string userId1, string userId2)
        {
            User user1 = FindUserById(userId1);
            User user2 = FindUserById(userId2);

            if (user1 == null || user2 == null)
            {
                Console.WriteLine("One or both users not found.");
                return;
            }

            user1.Friends.Remove(user2);
            user2.Friends.Remove(user1);

            Console.WriteLine($"Friend connection removed between {user1.Name} and {user2.Name}.");
        }
        //Find mutual Friend
        public void FindMutuals(string userId1, string userId2)
        {
            User user1 = FindUserById(userId1);
            User user2 = FindUserById(userId2);

            if (userId1 == null || user2 == null)
            {
                Console.WriteLine("One ore both users not found");
                return;
            }
            List<User> mutualFriends = new List<User>();
            foreach (var friend in user1.Friends)
            {
                if (user2.Friends.Contains(friend))
                {
                    mutualFriends.Add(friend);
                }
            }
            if (mutualFriends.Count == 0)
            {
                Console.WriteLine("No mutual friend found");
            }
            else
            {
                Console.WriteLine("Mutual Friends:");
                foreach (var friend in mutualFriends)
                {
                    Console.WriteLine(friend.Name);
                }
            }
        }
        //Display all friends of a specific user.
        public void DisplayFriends(string userId)
        {
            User user = FindUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }
            foreach (var friend in user.Friends)
            {
                Console.WriteLine(friend.Name);
            }
        }
        //Search for a user by Name or User ID.
        public void SearchUser(string query)
        {
            User temp = head;
            while (temp != null)
            {
                if (temp.UserId.ToString() == query || temp.Name.ToLower() == query.ToLower())
                {
                    Console.WriteLine($"User found: ID: {temp.UserId}, Name: {temp.Name}, Age: {temp.Age}");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("User not found.");
        }
        //Count the number of friends for each user.
        public void CountFriends()
        {
            User temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Name} has {temp.Friends.Count} friends.");
                temp = temp.Next;
            }
        }
    }
}
