export enum Status {
    Todo = 0,
    InProgress = 1,
    InTest = 2,
    Done = 3
}

export enum Priority {
    Low = 0,
    Medium = 1,
    High = 2,
    Highest = 3
}
  
export interface ITask {
    taskId: string;
    projectId: string | null;
    title: string;
    description: string | null;
    status: Status;
    userId: string | null;
    startDate: string;
    dueDate: string | null;
    priority: Priority;
}