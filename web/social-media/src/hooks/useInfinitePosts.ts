import { useInfiniteQuery } from "@tanstack/react-query";
import { fetchPosts } from "@/services/post-service";

export function useInfinitePosts() {
  return useInfiniteQuery({
    queryKey: ["posts"],
    queryFn: fetchPosts,
    initialPageParam: 1, 
    getNextPageParam: (lastPage) => lastPage.nextPage ?? undefined, 
  });
}
