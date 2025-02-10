"use client";

import { useInfinitePosts } from "@/hooks/useInfinitePosts";
import { useEffect, useRef } from "react";
import Post from "./post";
import NewPost from "./new-post";
import Filter from "./filter/filter";
import SearchBar from "./filter/search-bar";

const Feed = () => {
  const { data, fetchNextPage, hasNextPage, isFetchingNextPage } =
    useInfinitePosts();
  const observerRef = useRef<HTMLDivElement | null>(null);

  useEffect(() => {
    if (!observerRef.current || !hasNextPage) return;

    const observer = new IntersectionObserver(
      ([entry]) => {
        if (entry.isIntersecting) {
          fetchNextPage();
        }
      },
      { rootMargin: "100px" }
    );

    observer.observe(observerRef.current);
    return () => observer.disconnect();
  }, [hasNextPage, fetchNextPage]);  

  return (
    <div className="w-full">
      <Filter />

      <NewPost />

      <SearchBar/>

      
      
      {data?.pages.map((page) =>
        page.posts.map((post: any) => <Post key={post.id} {...post} />)
      )}

      <div ref={observerRef} className="h-10"></div>

      {isFetchingNextPage && (
        <p className="text-center text-gray-500">Loading more...</p>
      )}
    </div>
  );
};

export default Feed;
