"use client";

import { usePosts } from "../../hooks/usePosts";
import Post from "./post";
import NewPost from "./new-post";

const  Feed  = () => {
  const { data: posts, isLoading, error } = usePosts();

  if (isLoading) return <p className="text-center text-gray-400">Loading...</p>;

  if (error)
    return <p className="text-center text-red-500">Failed to load posts</p>;

  return (
    <div className="max-w-2xl mx-auto py-6 space-y-4">
      <NewPost />
      {posts?.map((post: any) => (
        <Post key={post.id} {...post} />
      ))}
    </div>
  );
}

export default Feed;
