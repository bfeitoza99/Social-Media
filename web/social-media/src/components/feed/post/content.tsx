import { PostResponseDTO } from "@/type/api/post";
import { Repeat } from "lucide-react";
import Avatar from "../avatar";
import { TruncatedText } from ".";
import { timeAgo } from "./helper";

const PostContent = ({
    post,
    onViewMore,
    isOwnPost,
    setIsDialogOpen,
    isPending,
  }: {
    post: PostResponseDTO;
    onViewMore: () => void;
    setIsDialogOpen: () => void;
    isOwnPost: boolean;
    isPending: boolean;
  }) => (
    <div className="ml-10">
      <TruncatedText text={post.content} onViewMore={onViewMore} />
  
      {!post.isRepost && (
        <div className="flex items-center space-x-6 text-gray-500 mt-3">
          <button
            className={`flex items-center space-x-1 ${
              isPending || isOwnPost
                ? "text-gray-500 cursor-not-allowed opacity-50 pointer-events-none"
                : "hover:text-blue-500 cursor-pointer"
            }`}
            onClick={setIsDialogOpen}
            disabled={isPending || isOwnPost}
          >
            <Repeat size={20} />
            <span>{post.repostCount}</span>
          </button>
        </div>
      )}
  
      {post.originalPost && (
        <div className="mt-3 border border-neutral-700 rounded-lg p-3 bg-neutral-900 ml-4">
          <div className="flex space-x-3">
            <Avatar src={post.originalPost.authorProfileImageUrl} size={30} />
            <div className="w-full">
              <div className="flex items-center space-x-2">
                <span className="text-gray-500">
                  {post.originalPost.authorNickname}
                </span>
                <span className="text-gray-500">
                  · {timeAgo(post.originalPost.createdAt) }
                </span>
              </div>
              <TruncatedText
                text={post.originalPost.content}
                onViewMore={onViewMore}
              />
            </div>
          </div>
        </div>
      )}
    </div>
  );

  
  export default PostContent;