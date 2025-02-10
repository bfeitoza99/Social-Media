"use client";

import { useState } from "react";
import Avatar from "./avatar";

const NewPost = () => {
  const [content, setContent] = useState("");

  return (
    <div className="border-b border-neutral-800 p-4 flex space-x-4">
      <Avatar src="https://i.pravatar.cc/50" />

      <div className="flex flex-col w-full">
        <textarea
          className="w-full bg-transparent text-white text-lg placeholder-gray-500 outline-none resize-none"
          rows={3}
          placeholder="What's happening?!"
          value={content}
          onChange={(e) => setContent(e.target.value)}
        />

        <div className="flex items-center mt-3 border-t border-neutral-800 pt-3">
          <button
            className={`ml-auto bg-blue-500 text-white font-bold px-6 py-2 rounded-full transition ${
              content.trim() === ""
                ? "opacity-50 cursor-not-allowed"
                : "hover:bg-blue-600"
            }`}
            disabled={content.trim() === ""}
          >
            Post
          </button>
        </div>
      </div>
    </div>
  );
};

export default NewPost;
