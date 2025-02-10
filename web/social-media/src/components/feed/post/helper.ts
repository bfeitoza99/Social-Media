import { formatDistanceToNowStrict } from "date-fns";

export const timeAgo = (createdAt: string) => { 
    return formatDistanceToNowStrict(new Date(createdAt), { addSuffix: false });
  };
