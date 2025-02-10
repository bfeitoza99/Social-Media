export interface OriginalPostDTO {
    id: number;
    content: string;
    authorNickname: string;
    authorProfileImageUrl: string;
    authorUserId: number;
    createdAt: string;
    repostCount: number;
    isRepost: boolean;
  }
  
  export interface PostResponseDTO {
    id: number;
    content: string;
    authorNickname: string;
    authorProfileImageUrl: string;
    authorUserId: number;
    createdAt: string;
    repostCount: number;
    isRepost: boolean;
    originalPost?: OriginalPostDTO | null;
  }
  
  export interface PaginatedPosts {
    items: PostResponseDTO[];
    totalCount: number;
    page: number;
    pageSize: number;
  }

  export enum PostOrderBy {
    Latest = 1,
    Trending = 2,
  }