"use client";

import Avatar from "./avatar";
import { useNewPost } from "@/hooks/useNewPost";

const NewPost = () => {
  const { content, setContent, handleSubmit, isPosting, selectedUser } = useNewPost();
  return (
    <div className="border-b border-neutral-800 pt-4 pb-2 flex space-x-4 pl-2">
      {selectedUser && <Avatar src={selectedUser.profileImageUrl} />}

      <div className="flex flex-col w-full">
        <textarea
          className="w-full bg-transparent text-white text-lg placeholder-gray-500 outline-none resize-none"
          rows={3}
          placeholder="What's happening?!"
          value={content}
          maxLength={777}
          onChange={(e) => setContent(e.target.value)}
        />

        <div className="flex items-center mt-3 border-t border-neutral-800 pt-3">
          <span className="text-gray-500 text-sm">{content.length}/777</span>
          <button
            className={`ml-auto bg-blue-500 text-white font-bold px-6 py-2 rounded-full transition ${
              content.trim() === ""
                ? "opacity-50 cursor-not-allowed"
                : "hover:bg-blue-600"
            }`}
            disabled={content.trim() === ""|| isPosting }
            onClick={() => handleSubmit()}
          >
            Post
          </button>
        </div>
      </div>
    </div>
  );
};

export default NewPost;
