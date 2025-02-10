"use client";

import { Repeat } from "lucide-react";
import Avatar from "./avatar";
import { formatDistanceToNowStrict } from "date-fns";
import { toZonedTime } from "date-fns-tz";

interface PostProps {
  authorProfileImageUrl: string;
  authorNickname: string;
  createdAt: string;
  content: string;
  repostCount: number;
}

const Post: React.FC<PostProps> = ({
  authorProfileImageUrl,
  authorNickname,
  createdAt,
  content,
  repostCount,
}) => {
  const timeAgo = (createdAt: string) => {
    const utcDate = new Date(createdAt + "Z");
    const timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;

    const localDate = toZonedTime(utcDate, timeZone);

    return formatDistanceToNowStrict(localDate, { addSuffix: false });
  };

  return (
    <div className="border-b border-neutral-800 p-4 flex space-x-4">
      <Avatar src={authorProfileImageUrl} size={40} />

      <div className="w-full">
        <div className="flex items-center space-x-2">
          <span className="text-gray-500">{authorNickname}</span>
          <span className="text-gray-500">· {timeAgo(createdAt)}</span>
        </div>
        <p className="text-white mt-1">{content}</p>
        <div className="flex items-center space-x-6 text-gray-500 mt-3">
          <div className="flex items-center space-x-1 hover:text-blue-500 cursor-pointer">
            <Repeat size={20} />
            <span>{repostCount}</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Post;
