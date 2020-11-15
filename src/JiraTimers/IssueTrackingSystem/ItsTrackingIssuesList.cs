﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();

		public void AddItem(IItsTrackingIssue issue)
		{
			Items.Add(issue);
		}

		public void UpdateItem(string id, IItsIssue issue)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			var existingIssue = Items.First(x => x.Issue.ID == id);

			existingIssue.Issue.Key = issue.Key;
			existingIssue.Issue.Summary = issue.Summary;
		}

		public void RemoveItem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			Items.Remove(Items.First(x => x.Issue.ID == id));
		}
	}
}