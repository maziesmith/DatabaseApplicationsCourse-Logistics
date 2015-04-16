using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using Logistics.Infrastructure.NRepositories;
using Logistics.Application.Services;
using Logistics.Domain.Model;
using Logistics.Domain.Repositories;

namespace Logistics.Application.Services
{
	public class ApplicationService : IApplicationService
	{
		private IUserRepository _userRepository;
		private IOrderRepository _orderRepository;
		private INotificationRepository _notificationRepository;
		private ILogRepository _logRepository;

		public ApplicationService ()
		{
			_userRepository = new UserRepository ();
			_orderRepository = new OrderRepository ();
			_notificationRepository = new NotificationRepository ();
			_logRepository = new LogRepository ();
		}

		public ApplicationService( IUserRepository userRepository, IOrderRepository orderRepository, INotificationRepository notificationRepository, ILogRepository logRepository )
		{
			_userRepository = userRepository;
			_orderRepository = orderRepository;
			_notificationRepository = notificationRepository;
			_logRepository = logRepository;
		}

		public void AddOrderToUserAndDriver (Order order, User client, User driver)
		{
			Notification notification = CreateNewNotification (order, Status.INFORMATION_RECEIVED, client );
			_notificationRepository.Insert(notification);

			order.Client = client;
			order.Driver = driver;
			_orderRepository.Insert (order);
		}

		public Notification CreateNewNotification (Order order, Status status, User client )
		{
			Notification notification = new Notification ();
			switch (status) {				
				case Status.INFORMATION_RECEIVED:
				{
					notification.User = client;
					notification.ShortValue = "Dodano nową paczkę do systemu.";
					notification.FullValue = "Dodano nową paczkę do systemu. Numer przesyłki to " + order.Id;
					notification.NotificationType = NotificationType.SMS;
					break;
				}

				case Status.WAITING_FOR_TRANSPORT_SPACE:
				{
					notification.User = client;
					notification.ShortValue = "Oczekiwanie na przetworzenie.";
					notification.FullValue = "Oczekiwanie na przetworzenie zamównia przez system i dyspozycyjnego kierowcę.";
					notification.NotificationType = NotificationType.SMS;
					_notificationRepository.Insert(notification);
					break;
				}

				case Status.DRIVER_HAS_ORDER:
				{
					notification.User = client;
					notification.ShortValue = "Kierowca otrzymał paczkę.";
					notification.FullValue = "Kierowca otrzymał paczkę o numerze " + order.Id + ". Numer kontaktowy kierowcy to " + order.Driver.PhoneNumber;
					notification.NotificationType = NotificationType.SMS;
					_notificationRepository.Insert(notification);
					break;
				}
			}	
			return notification;
		}

		public void ChangeNotificationForUser (Notification notification, Status status , User user)
		{
			Notification oldNotification = _notificationRepository.FindAllForUser(user).FirstOrDefault(n => n.Id == notification.Id);
			Notification newNotification = CreateNewNotification (oldNotification.Order, Status.DRIVER_HAS_ORDER, user);
			_notificationRepository.Delete (oldNotification.Id);
			_notificationRepository.Insert (newNotification);
		}

		public void SendNotificationToAllClients (Notification notification)
		{
			IList<User>clients = _userRepository.FindAllWithRole (Role.CLIENT);
			foreach (User c in clients)
			{
				notification.User = c;
				_notificationRepository.Insert (notification);
			}
		}

		public void SendNotificationToAllDrivers (Notification notification)
		{
			IList<User>clients = _userRepository.FindAllWithRole (Role.DRIVER);
			foreach (User c in clients)
			{
				notification.User = c;
				_notificationRepository.Insert (notification);
			}
		}

		public void SendNotificationToAllAdmins(Notification notification)
		{
			IList<User>clients = _userRepository.FindAllWithRole (Role.ADMIN);
			foreach (User c in clients)
			{
				notification.User = c;
				_notificationRepository.Insert (notification);
			}
		}

		public void SendNotificationToAllUsers(Notification notification)
		{
			IList<User>clients = _userRepository.FindAll();
			foreach (User c in clients)
			{
				notification.User = c;
				_notificationRepository.Insert (notification);
			}
		}

		public void DeleteAllNotificationFromUser (User user)
		{
			IList<Notification>notifications = _notificationRepository.FindAll();
			foreach (Notification n in notifications)
			{
				if (n.User == user) {
					_notificationRepository.Delete (n.Id);
				}
			}
		}

		public IList<Order> GetAllOrdersFromDriver (User driver)
		{
			IList<Order>orders = _orderRepository.FindAll();
			return orders.Where(o => o.Driver == driver).ToList();
		}
	}
}

