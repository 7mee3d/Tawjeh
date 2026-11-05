# Tawjeh — My Learning Journey

## About This Repository

This repository documents my learning journey in software development, where I organize the concepts, skills, assignments, and practical projects I work on.

The repository is structured into multiple **Levels**, and each Level contains a set of **Sprints**. Each Sprint focuses on specific topics and skills, followed by practical tasks and projects to apply what I have learned.

## Level 1 — Sprint 1

### Collections & Generics

The first sprint focuses on strengthening my C# fundamentals by understanding collections, generics, and how to choose the right data structure based on its purpose and usage.

### What I Learned and Practiced

- **Collections:** `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>`, `Queue<T>`, and `Stack<T>`.
- **Generics:** Generic Methods and Generic Classes.
- **Type Constraints:** Understanding and using `where` constraints and `IEntity`.
- **Git & GitHub:** Repository management, commits, pushing changes, and pulling updates.

### Practical Project — Job Application Tracker

To apply the concepts covered in this sprint, I built a console-based application using C# and .NET called **Job Application Tracker**.

The application manages companies, recruiters, jobs, candidates, and job applications using in-memory data storage.

Some of the concepts I applied in the project include:

- Building a reusable generic `DataStore<T>` to manage entities.
- Using a `Dictionary<int, Job>` to find jobs by their IDs.
- Using a `HashSet<string>` to prevent duplicate candidate email addresses.
- Using a `HashSet<(int JobId, int CandidateId)>` to prevent duplicate job applications.
- Using a `Stack` to implement undo functionality for company status changes.

### Sprint Goal

The goal of this sprint was not just to learn different collection types and generics, but to understand when and why to use each one and apply them in a practical project.

---

**This repository will continue to grow as I progress through future levels and sprints.**
