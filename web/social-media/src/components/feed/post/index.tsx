"use client";

import { useState } from "react";
import { Repeat } from "lucide-react";
import { formatDistanceToNowStrict } from "date-fns";
import { toZonedTime } from "date-fns-tz";
import { usePostActions } from "@/hooks/usePostActions";
import { PostResponseDTO } from "@/type/api/post";
import Avatar from "../avatar";
import PostModal from "./post-dialog";
import ConfirmDialog from "../repost/confirm-dialog";
import PostContent from "./content";
import { timeAgo } from "./helper";

const MAX_LENGTH = 250;

export const TruncatedText = ({
  text = "",
  onViewMore,
}: {
  text: string | undefined;
  onViewMore: () => void;
}) => (
  <p className="text-white mt-1">
    {text && text.length > MAX_LENGTH ? (
      <>
        {text.substring(0, MAX_LENGTH)}...
        <button
          onClick={onViewMore}
          className="text-blue-500 ml-2 hover:underline"
        >
          View More
        </button>
      </>
    ) : (
      text
    )}
  </p>
);

const Post: React.FC<PostResponseDTO> = (post: PostResponseDTO) => {
  const {
    isDialogOpen,
    setIsDialogOpen,
    handleConfirmRepost,
    isPending,
    selectedUser,
  } = usePostActions(post.id);

  const [isModalOpen, setIsModalOpen] = useState(false);
  const isOwnPost = selectedUser?.id === post.authorUserId;

  return (
    <div className="border-b border-neutral-800 p-4 flex flex-col">
      <div className="flex items-center space-x-2">
        <Avatar src={post.authorProfileImageUrl} size={40} />
        <span className="text-gray-500 font-bold">{post.authorNickname}</span>
        <span className="text-gray-500">· {timeAgo(post.createdAt)}</span>

        {post.isRepost && (
          <div className="flex items-center space-x-1 text-gray-500 text-sm">
            <Repeat size={16} />
            <span>reposted</span>
          </div>
        )}
      </div>

      <PostContent
        post={post}
        isOwnPost={isOwnPost}
        isPending={isPending}
        setIsDialogOpen={() => setIsDialogOpen(true)}
        onViewMore={() => setIsModalOpen(true)}
      />

      <PostModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        content={
          post.isRepost ? post.originalPost?.content ?? "" : post.content
        }
        authorNickname={
          post.isRepost
            ? post.originalPost?.authorNickname ?? ""
            : post.authorNickname
        }
      />

      <ConfirmDialog
        isOpen={isDialogOpen}
        onConfirm={handleConfirmRepost}
        onCancel={() => setIsDialogOpen(false)}
      />
    </div>
  );
};

export default Post;
